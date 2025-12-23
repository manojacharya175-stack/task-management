using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(Guid userId, CreateTaskRequest request);
    Task<IEnumerable<TaskDto>> GetByUserAsync(Guid userId);
}
