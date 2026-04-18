using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Xml.Linq;
using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Interfaces.Persistence;
using ToDoManagement.Application.Interfaces.Repositories;
using ToDoManagement.Application.UseCases.Categories.CreateCategory;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Tests.Application.UseCases.Categories;

public class UseCaseCreateCategoryTests
{
    private IRepositoryCategory _repository;
    private IUnitOfWork _unitOfWork;
    private UseCaseCreateCategory _useCase;

    public UseCaseCreateCategoryTests()
    {
        _repository = Substitute.For<IRepositoryCategory>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _useCase = new UseCaseCreateCategory(_repository, _unitOfWork);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsId()
    {
        // Arrange
        var command = new CreateCategoryCommand() { Name = "Principal" };

        var categoryCreated = new Category("Principal");
        _repository.AddAsync(Arg.Any<Category>()).Returns(categoryCreated);

        // Act
        var result = await _useCase.Handle(command);

        // Assert
        await _repository.Received(1).AddAsync(Arg.Any<Category>());
        await _unitOfWork.Received(1).SaveAsync();
        await _unitOfWork.Received(0).RollbackAsync();
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task Handle_WhenError_DoRollback()
    {
        // Arrange
        var command = new CreateCategoryCommand() { Name = "Principal" };
        _repository.AddAsync(Arg.Any<Category>()).Throws<Exception>();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await _useCase.Handle(command);
        });

        await _repository.Received(1).AddAsync(Arg.Any<Category>());
        await _unitOfWork.DidNotReceive().SaveAsync();
        await _unitOfWork.Received(1).RollbackAsync();
    }
}
