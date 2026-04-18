using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;

public class UseCaseGetDetailCategory : IRequestHandler<GetDetailCategoryQuery, DetailCategoryDTO>
{
    private readonly IRepositoryCategory _repository;

    public UseCaseGetDetailCategory(IRepositoryCategory repository)
    {
        _repository = repository;
    }

    public async Task<DetailCategoryDTO> Handle(GetDetailCategoryQuery request)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if(category is null)
        {
            throw new AppNotFoundException();
        }

        var dto = new DetailCategoryDTO { Id = category.Id, Name = category.Name };
        return dto;
    }
}
