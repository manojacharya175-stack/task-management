using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
}
