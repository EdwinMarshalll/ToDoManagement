using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailUseCase : IRequestHandler<GetCategoryDetailQuery, CategoryDetailDto>
{
    private readonly IRepositoryCategory _repository;

    public GetCategoryDetailUseCase(IRepositoryCategory repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDetailDto> Handle(GetCategoryDetailQuery request)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if(category is null)
        {
            throw new AppNotFoundException();
        }

        return category.ToDto();
    }
}
