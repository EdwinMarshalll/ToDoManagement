namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategories;

public class CategoryListItemDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
