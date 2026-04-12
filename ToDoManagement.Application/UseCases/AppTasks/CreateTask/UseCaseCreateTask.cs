using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Application.UseCases.AppTasks.CreateTask;

public class UseCaseCreateTask
{
    private readonly IRepositoryAppTask _repository;

    public UseCaseCreateTask(IRepositoryAppTask repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CommandCreateTask command)
    {
        AppTask appTask = new (command.Name, command.CategoryId, command.Notes, command.ExpiresAt, command.AttachmentUrl);
        var response = await _repository.AddAsync(appTask);
        return response.Id;
    }
}
