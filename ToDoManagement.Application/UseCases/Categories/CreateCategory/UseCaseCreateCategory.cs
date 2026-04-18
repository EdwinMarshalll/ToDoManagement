using ToDoManagement.Application.Interfaces.Persistence;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.Utilities.Mediator;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.Categories.CreateCategory;

public class UseCaseCreateCategory : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IRepositoryCategory _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UseCaseCreateCategory(IRepositoryCategory repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCategoryCommand command)
    {
        Category category = new(command.Name);
        try
        {
            var response = await _repository.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return response.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
