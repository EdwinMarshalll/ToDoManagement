using ToDoManagement.Application.Interfaces.Repositories;
using NSubstitute;
using ToDoManagement.Application.UseCases.Categories.Queries.GetCategories;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Tests.Application.UseCases.Categories;

public class GetCategoriesUseCaseTests
{
    private IRepositoryCategory _repository;
    private GetCategoriesUseCase _useCase;

    public GetCategoriesUseCaseTests()
    {
        _repository = Substitute.For<IRepositoryCategory>();
        _useCase = new GetCategoriesUseCase(_repository);
    }

    [Fact]
    public async Task Handle_WhenThereAreCategories_ReturnsListOfCategoryListItemDto()
    {
        var categories = new List<Category>()
        {
            new ("Principal"),
            new ("Trabajo")
        };

        _repository.GetAllAsync().Returns(categories);

        var expected = categories.Select(category => new CategoryListItemDto()
        {
            Id = category.Id,
            Name = category.Name
        }).ToList();

        // Act
        var result = await _useCase.Handle(new GetCategoriesQuery());

        // Assert
        Assert.Equal(expected.Count, result.Count);

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i].Id, result[i].Id);
            Assert.Equal(expected[i].Name, result[i].Name);
        }
    }

    [Fact]
    public async Task Handle_WhenThereAreNotCategories_ReturnsEmptyList()
    {
        _repository.GetAllAsync().Returns(new List<Category>());

        var result = await _useCase.Handle(new GetCategoriesQuery());

        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
