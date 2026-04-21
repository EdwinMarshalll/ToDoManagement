using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Persistence.Repositories;

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

        return services;
    }
}
