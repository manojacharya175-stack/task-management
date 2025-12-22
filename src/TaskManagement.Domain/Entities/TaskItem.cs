using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public TaskManagement.Domain.Enums.TaskStatus Status { get; private set; }
    public Guid UserId { get; private set; }

    private TaskItem() { } // For ORM only (kept internal to domain)

    public TaskItem(string title, Guid userId, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Task title cannot be empty.");

        Title = title;
        Description = description;
        UserId = userId;
        Status = TaskManagement.Domain.Enums.TaskStatus.Pending;
    }

    public void UpdateDetails(string title, string? description)
    {
        Title = title;
        Description = description;
        MarkUpdated();
    }

    public void ChangeStatus(TaskManagement.Domain.Enums.TaskStatus status)
    {
        Status = status;
        MarkUpdated();
    }
}
