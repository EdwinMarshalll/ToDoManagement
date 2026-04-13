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
    private IValidator<CreateCategoryCommand> _validator;
    private UseCaseCreateCategory _useCase;

    public UseCaseCreateCategoryTests()
    {
        _repository = Substitute.For<IRepositoryCategory>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _validator = Substitute.For<IValidator<CreateCategoryCommand>>();
        _useCase = new UseCaseCreateCategory(_repository, _unitOfWork, _validator);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsId()
    {
        // Arrange
        var command = new CreateCategoryCommand() { Name = "Principal" };

        _validator.ValidateAsync(command).Returns(new ValidationResult());

        var categoryCreated = new Category("Principal");
        _repository.AddAsync(Arg.Any<Category>()).Returns(categoryCreated);

        // Act
        var result = await _useCase.Handle(command);

        // Assert
        await _validator.Received(1).ValidateAsync(command);
        await _repository.Received(1).AddAsync(Arg.Any<Category>());
        await _unitOfWork.Received(1).SaveAsync();
        await _unitOfWork.Received(0).RollbackAsync();
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ThrowsException()
    {
        // Arrange
        var command = new CreateCategoryCommand() { Name = ""};
        var resultadoInvalido = new ValidationResult(new[]
        {
            new ValidationFailure("Name", "El nombre es requerido")
        });

        _validator.ValidateAsync(command).Returns(resultadoInvalido);

        // Act & Assert
        await Assert.ThrowsAsync<ApplicationValidationException>( async () => 
        {
            await _useCase.Handle(command);
        });

        await _repository.DidNotReceive().AddAsync(Arg.Any<Category>());
        await _unitOfWork.DidNotReceive().SaveAsync();
        await _unitOfWork.DidNotReceive().RollbackAsync();
    }

    [Fact]
    public async Task Handle_WhenError_DoRollback()
    {
        // Arrange
        var command = new CreateCategoryCommand() { Name = "Principal" };
        _repository.AddAsync(Arg.Any<Category>()).Throws<Exception>();
        _validator.ValidateAsync(command).Returns(new ValidationResult());

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
