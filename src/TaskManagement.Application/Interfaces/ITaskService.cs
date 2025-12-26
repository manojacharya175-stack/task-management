using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(Guid userId, CreateTaskRequest request);

    Task<IEnumerable<TaskDto>> GetByUserAsync(Guid userId);

    Task<TaskDto> UpdateAsync(UpdateTaskRequest request);

    Task DeleteAsync(int id);

    Task<TaskDto> GetByIdAsyc(int id);
}
