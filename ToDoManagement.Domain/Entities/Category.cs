using ToDoManagement.Domain.Exceptions;

namespace ToDoManagement.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainValidationException($"El {nameof(name)} es requerido.");
        }

        Id = Guid.CreateVersion7();
        Name = name;
    }
}
