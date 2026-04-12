using FluentValidation;

namespace ToDoManagement.Application.UseCases.Categories.CreateCategory;

public class ValidatorCommandCreateCategory: AbstractValidator<CommandCreateCategory>
{
    public ValidatorCommandCreateCategory()
    {
        RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("El campo {PropertyName} es querido");
    }
}
