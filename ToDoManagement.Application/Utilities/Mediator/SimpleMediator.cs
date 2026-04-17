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
        var useCaseType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

        var useCase = _serviceProvider.GetService(useCaseType);

        if(useCase is null)
        {
            throw new MediatorException($"No se ha encontrado un handler para {request.GetType().Name}");
        }

        var method = useCaseType.GetMethod("Handle")!;
        return await (Task<TResponse>)method.Invoke(useCase, new object[] { request })!;
    }
}
