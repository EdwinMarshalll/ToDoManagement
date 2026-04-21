using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoManagement.Application.Interfaces.Persistence;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Persistence.Repositories;
using ToDoManagement.Persistence.UnitOfWorks;

namespace ToDoManagement.Persistence;

public static class PersistenceServicesRegister
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("name=ToDoManagementConnectionString");
        });

        services.AddScoped<IRepositoryCategory, RepositoryCategory>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

        return services;
    }
}
