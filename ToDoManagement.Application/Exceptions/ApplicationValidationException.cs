using FluentValidation.Results;

namespace ToDoManagement.Application.Exceptions;

public class ApplicationValidationException : Exception
{
    public List<string> ValidationErrors { get; set; } = [];

    public ApplicationValidationException(ValidationResult validationResult)
    {
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}
