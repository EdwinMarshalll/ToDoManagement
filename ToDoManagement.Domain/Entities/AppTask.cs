using ToDoManagement.Domain.Exceptions;

namespace ToDoManagement.Domain.Entities;

public class AppTask
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsCompleted { get; set; }
    public string? Notes { get; private set; }
    public DateTime? ExpiresAt { get; private set; }
    public string? AttachmentUrl { get; private set; }
    public Guid CategoryId { get; private set; }

    public AppTask(string name, Guid categoryId, string? notes = null, DateTime? expiresAt = null, string? attachmentUrl = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainValidationException($"El {nameof(name)} es requerido");
        }

        Id = Guid.CreateVersion7();
        IsCompleted = false;

        Name = name;
        CategoryId = categoryId;
        Notes = notes;
        ExpiresAt = expiresAt;
        AttachmentUrl = attachmentUrl;
    }

    public void Complete()
    {
        IsCompleted = true;
    }

    public void Uncomplete()
    {
        IsCompleted = false;
    }
}
