namespace ToDoManagement.Application.UseCases.AppTasks.CreateTask;

public class CommandCreateTask
{
    public required string Name { get; set; }
    public required Guid CategoryId { get; set; }
    public string? Notes { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public string? AttachmentUrl { get; set; }
}
