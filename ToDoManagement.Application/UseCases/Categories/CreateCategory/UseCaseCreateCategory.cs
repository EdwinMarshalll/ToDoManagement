using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.Categories.CreateCategory;

public class UseCaseCreateCategory
{
    private readonly IRepositoryCategory _repository;

    public UseCaseCreateCategory(IRepositoryCategory repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CommandCreateCategory command)
    {
        Category category = new (command.Name) ;
        var response = await _repository.AddAsync(category);
        return response.Id ;
    }
}
