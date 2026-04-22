using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailQuery : IRequest<CategoryDetailDto>
{
    public Guid Id { get; set; }
}
