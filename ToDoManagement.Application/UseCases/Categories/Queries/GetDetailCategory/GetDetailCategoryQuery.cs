using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;

public class GetDetailCategoryQuery : IRequest<DetailCategoryDTO>
{
    public Guid Id { get; set; }
}
