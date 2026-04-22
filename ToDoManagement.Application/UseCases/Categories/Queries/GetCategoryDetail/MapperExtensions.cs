using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategoryDetail;

public static class MapperExtensions
{
    public static CategoryDetailDto ToDto(this Category category)
    {
        var dto = new CategoryDetailDto { 
            Id = category.Id, 
            Name = category.Name 
        };

        return dto;
    }
}
