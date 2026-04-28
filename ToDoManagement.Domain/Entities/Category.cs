using ToDoManagement.Domain.Exceptions;

namespace ToDoManagement.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public Category(string name)
    {
        ApplyBusinessRulesForName(name);

        Id = Guid.CreateVersion7();
        Name = name;
    }

    public void UpdateName(string name)
    {
        ApplyBusinessRulesForName(name);
        Name = name;
    }

    private void ApplyBusinessRulesForName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"El {nameof(name)} es obligatorio");
        }
    }
}
