using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Tasks;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> CreateAsync(Guid userId, CreateTaskRequest request)
    {
        var task = new TaskItem(
            request.Title,
            userId,
            request.Description
        );

        await _taskRepository.AddAsync(task);

        return MapToDto(task);
    }

    public async Task<IEnumerable<TaskDto>> GetByUserAsync(Guid userId)
    {
        var tasks = await _taskRepository.GetByUserIdAsync(userId);

        return tasks.Select(MapToDto);
    }

    private static TaskDto MapToDto(TaskItem task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString()
        };
    }
}
