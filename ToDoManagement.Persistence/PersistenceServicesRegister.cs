using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoManagement.Persistence;

public static class PersistenceServicesRegister
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("name=ToDoManagementConnectionString");
        });

        return services;
    }
}
