using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
