namespace TaskManagement.Application.DTOs;

public class CreateTaskRequest
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
