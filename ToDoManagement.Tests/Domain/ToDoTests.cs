using ToDoManagement.Domain.Entities;
using ToDoManagement.Domain.Exceptions;

namespace ToDoManagement.Tests.Domain;

public class ToDoTests
{
    [Fact]
    public void Constructor_NullName_ThrowsException()
    {
        // Arrange
        string name = null!;
        Guid categoryId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<DomainValidationException>(() =>
        {
            ToDo todo = new(name, categoryId);
        });
    }

    [Fact]
    public void Constructor_EmptyName_ThrowsException()
    {
        // Arrange
        string name = "";
        Guid categoryId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<DomainValidationException>(() =>
        {
            ToDo todo = new(name, categoryId);
        });
    }

    [Fact]
    public void Constructor_MinimumValidParameters_CreateToDo()
    {
        // Arrange
        string name = "Comprar libro 'La sombra sobre innsmouth'";
        Guid categoryId = Guid.NewGuid();

        // Act
        ToDo todo = new(name, categoryId);

        // Assert
        Assert.NotNull(todo);
        Assert.IsType<Guid>(todo.Id);
        Assert.Equal(name, todo.Name);
        Assert.Equal(categoryId, todo.CategoryId);
        Assert.False(todo.IsCompleted);
        Assert.Null(todo.Notes);
        Assert.Null(todo.ExpiresAt);
        Assert.Null(todo.AttachmentUrl);
    }

    [Fact]
    public void Constructor_AllParameters_CreateToDo()
    {
        // Arrange
        string name = "Comprar libro 'La sombra sobre innsmouth'";
        Guid categoryId = Guid.NewGuid();
        string notes = "Libro de terror en amazon";
        DateTime expiresAt = DateTime.Now.AddDays(10);
        string attachmentUrl = "https://dominio.com/file1";

        // Act
        ToDo todo = new(name, categoryId, notes, expiresAt, attachmentUrl);

        // Assert
        Assert.NotNull(todo);
        Assert.IsType<Guid>(todo.Id);
        Assert.Equal(name, todo.Name);
        Assert.Equal(categoryId, todo.CategoryId);
        Assert.False(todo.IsCompleted);
        Assert.Equal(notes, todo.Notes);
        Assert.Equal(expiresAt, todo.ExpiresAt);
        Assert.Equal(attachmentUrl, todo.AttachmentUrl);
    }

    [Fact]
    public void Complete_MarksAsCompleted()
    {
        ToDo todo = new("Comprar algo", Guid.NewGuid());
        todo.Complete();

        Assert.True(todo.IsCompleted);
    }

    [Fact]
    public void Uncomplete_MarksAsUncompleted()
    {
        ToDo todo = new("Comprar algo", Guid.NewGuid());
        todo.Complete();

        todo.Uncomplete();
        Assert.False(todo.IsCompleted);
    }
}
