
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Persistence.Repositories;

public class RepositoryCategory : Repository<Category>, IRepositoryCategory
{
    public RepositoryCategory(AppDbContext context) : base(context)
    {
        
    }
}
