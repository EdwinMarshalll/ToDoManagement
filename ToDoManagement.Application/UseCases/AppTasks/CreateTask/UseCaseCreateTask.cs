using ToDoManagement.Application.Interfaces.Persistence;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.AppTasks.CreateTask;

public class UseCaseCreateTask
{
    private readonly IRepositoryAppTask _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UseCaseCreateTask(IRepositoryAppTask repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CommandCreateTask command)
    {
        AppTask appTask = new (command.Name, command.CategoryId, command.Notes, command.ExpiresAt, command.AttachmentUrl);
        try
        {
            var response = await _repository.AddAsync(appTask);
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
