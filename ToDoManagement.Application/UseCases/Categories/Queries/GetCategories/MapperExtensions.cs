using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategories;

public static class MapperExtensions
{
    public static CategoryListItemDto ToDto(this Category category)
    {
        var dto = new CategoryListItemDto { Id = category.Id, Name = category.Name };
        return dto;
    }
}
