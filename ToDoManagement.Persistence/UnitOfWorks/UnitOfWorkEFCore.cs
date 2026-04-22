using ToDoManagement.Application.Interfaces.Persistence;

namespace ToDoManagement.Persistence.UnitOfWorks;

public class UnitOfWorkEFCore : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWorkEFCore(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task RollbackAsync()
    {
        // In EFCore rollback is implicit
        return Task.CompletedTask;
    }
}
