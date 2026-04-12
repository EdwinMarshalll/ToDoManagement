using FluentValidation;

namespace ToDoManagement.Application.UseCases.AppTasks.CreateTask;

public class ValidatorCommandCreateTask: AbstractValidator<CommandCreateTask>
{
    public ValidatorCommandCreateTask()
    {
        RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
    }
}
