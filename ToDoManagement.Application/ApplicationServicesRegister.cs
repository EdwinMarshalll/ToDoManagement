using Microsoft.Extensions.DependencyInjection;
using ToDoManagement.Application.UseCases.Categories.Commands.CreateCategory;
using ToDoManagement.Application.UseCases.Categories.Commands.UpdateCategory;
using ToDoManagement.Application.UseCases.Categories.Queries.GetCategories;
using ToDoManagement.Application.UseCases.Categories.Queries.GetCategoryDetail;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Application;

public static class ApplicationServicesRegister
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMediator, SimpleMediator>();

        services.AddScoped<IRequestHandler<CreateCategoryCommand, Guid>, CreateCategoryUseCase>();
        services.AddScoped<IRequestHandler<GetCategoryDetailQuery, CategoryDetailDto>, GetCategoryDetailUseCase>();
        services.AddScoped<IRequestHandler<GetCategoriesQuery,  List<CategoryListItemDto>>, GetCategoriesUseCase>();
        services.AddScoped<IRequestHandler<UpdateCategoryCommand>, UpdateCategoryUseCase>();
        return services;
    }
}
