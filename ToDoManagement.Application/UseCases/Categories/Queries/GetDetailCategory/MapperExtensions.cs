using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;

public static class MapperExtensions
{
    public static DetailCategoryDTO ToDto(this Category category)
    {
        var dto = new DetailCategoryDTO { 
            Id = category.Id, 
            Name = category.Name 
        };

        return dto;
    }
}
