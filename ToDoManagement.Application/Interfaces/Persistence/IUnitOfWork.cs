namespace ToDoManagement.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task SaveAsync();
    Task RollbackAsync();
}
