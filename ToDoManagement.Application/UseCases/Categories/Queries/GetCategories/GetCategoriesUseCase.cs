using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategories;

public class GetCategoriesUseCase : IRequestHandler<GetCategoriesQuery, List<CategoryListItemDto>>
{
    private readonly IRepositoryCategory _repository;

    public GetCategoriesUseCase(IRepositoryCategory repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryListItemDto>> Handle(GetCategoriesQuery request)
    {
        var categories = await _repository.GetAllAsync();    
        var categoriesDtos = categories.Select(category => category.ToDto()).ToList();
        return categoriesDtos;
    }
}
