namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategoryDetail;

public class CategoryDetailDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
