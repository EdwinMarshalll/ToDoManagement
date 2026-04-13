using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
