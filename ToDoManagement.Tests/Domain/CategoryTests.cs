using ToDoManagement.Domain.Entities;
using ToDoManagement.Domain.Exceptions;

namespace ToDoManagement.Tests.Domain;

public class CategoryTests
{
    [Fact]
    public void Constructor_NullName_ThrowsException()
    {
        // Arrange
        string name = null!;

        // Act & Assert
        Assert.Throws<DomainValidationException>(() =>
        {
            Category category = new (name); 
        });
    }

    [Fact]
    public void Contrusctor_EmptyName_ThrowsException()
    {
        // Arrange
        string name = "";

        // Act & Assert
        Assert.Throws<DomainValidationException>(() =>
        {
            Category category = new(name);
        });
    }

    [Fact]
    public void Constructor_ValidName_CreateCategory()
    {
        // Arrange
        string name = "Principal";

        // Act
        Category category = new(name);

        // Assert
        Assert.NotNull(category);
        Assert.Equal(name, category.Name);
        Assert.IsType<Guid>(category.Id);
    }
}
