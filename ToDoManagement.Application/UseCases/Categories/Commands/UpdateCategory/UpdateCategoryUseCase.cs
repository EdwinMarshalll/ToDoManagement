using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Interfaces.Persistence;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application.UseCases.Categories.Commands.UpdateCategory;

public class UpdateCategoryUseCase : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepositoryCategory _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryUseCase(IRepositoryCategory repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request)
    {
        var category = await _repository.GetByIdAsync(request.Id);
        if (category is null)
        {
            throw new AppNotFoundException();
        }

        category.UpdateName(request.Name);

        try
        {
            await _repository.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
