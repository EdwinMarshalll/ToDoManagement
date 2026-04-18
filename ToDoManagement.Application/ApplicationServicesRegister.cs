using Microsoft.Extensions.DependencyInjection;
using ToDoManagement.Application.UseCases.Categories.CreateCategory;
using ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application;

public static class ApplicationServicesRegister
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateCategoryCommand, Guid>, 
            UseCaseCreateCategory>();

        services.AddScoped<IRequestHandler<GetDetailCategoryQuery, DetailCategoryDTO>,
            UseCaseGetDetailCategory>();

        return services;
    }
}
