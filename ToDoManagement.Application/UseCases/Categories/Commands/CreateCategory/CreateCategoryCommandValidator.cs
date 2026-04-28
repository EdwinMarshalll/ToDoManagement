using FluentValidation;

namespace ToDoManagement.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("El campo {PropertyName} es querido")
            .MaximumLength(150).WithMessage("La longitud del campo {PropertyName} debe ser menor o igual a {MaxLength}");
    }
}
