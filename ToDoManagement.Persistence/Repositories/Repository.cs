using Microsoft.EntityFrameworkCore;
using ToDoManagement.Application.Interfaces.Repositories;

namespace ToDoManagement.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public Task<T> AddAsync(T entity)
    {
        _context.Add(entity);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }
}
