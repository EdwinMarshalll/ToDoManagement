using FluentValidation;
using FluentValidation.Results;
using ToDoManagement.Application.Exceptions;

namespace ToDoManagement.Application.Utilities.Mediator;

public class SimpleMediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public SimpleMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        var validator = _serviceProvider.GetService(validatorType);

        if (validator is not null)
        {
            var validatorMethod = validatorType.GetMethod("ValidateAsync");
            var taskValidate = (Task)validatorMethod!.Invoke(validator, new object[] { request, CancellationToken.None })!;

            await taskValidate.ConfigureAwait(false); // En aspnet core no sirve de nada por que no tenemos un contexto de sincronizacion.

            var result = taskValidate.GetType().GetProperty("Result");
            var validationResult = (ValidationResult)result!.GetValue(taskValidate)!;

            if (!validationResult.IsValid)
            {
                throw new ApplicationValidationException(validationResult);
            }
        }

        var useCaseType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var useCase = _serviceProvider.GetService(useCaseType);

        if (useCase is null)
        {
            throw new MediatorException($"No se ha encontrado un handler para {request.GetType().Name}");
        }

        var method = useCaseType.GetMethod("Handle")!;
        return await (Task<TResponse>)method.Invoke(useCase, new object[] { request })!;
    }
}
