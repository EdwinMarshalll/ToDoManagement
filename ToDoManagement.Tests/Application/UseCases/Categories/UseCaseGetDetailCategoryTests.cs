using NSubstitute;
using NSubstitute.ReturnsExtensions;
using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Tests.Application.UseCases.Categories;

public class UseCaseGetDetailCategoryTests
{
    private IRepositoryCategory _repository;
    private UseCaseGetDetailCategory _useCase;

    public UseCaseGetDetailCategoryTests()
    {
        _repository = Substitute.For<IRepositoryCategory>();
        _useCase = new UseCaseGetDetailCategory(_repository);
    }

    [Fact]
    public async Task Handle_CategoryExists_ReturnsCategoryDto()
    {
        // Arrange
        var category = new Category("Principal");
        var query = new GetDetailCategoryQuery() { Id = category.Id };

        _repository.GetByIdAsync(category.Id).Returns(category);

        // Act
        var result = await _useCase.Handle(query);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<DetailCategoryDTO>(result);
        Assert.Equal(category.Id, result.Id);
        Assert.Equal("Principal", result.Name);
    }

    [Fact]
    public async Task Handle_CategoryNotExists_ThrowsAppNotFoundException()
    {
        // Arrange
        var id = Guid.NewGuid();
        var query = new GetDetailCategoryQuery() { Id = id};

        _repository.GetByIdAsync(id).ReturnsNull();

        // Act & Assert
        await Assert.ThrowsAsync<AppNotFoundException>(async () => { 
            await _useCase.Handle(query);
        });
    }
}
