using FluentValidation;

namespace ToDoManagement.Application.UseCases.Categories.CreateCategory;

public class ValidatorCreateCategoryCommand: AbstractValidator<CreateCategoryCommand>
{
    public ValidatorCreateCategoryCommand()
    {
        RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("El campo {PropertyName} es querido");
    }
}
