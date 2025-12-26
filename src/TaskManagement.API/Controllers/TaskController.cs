using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        // Temporary userId
        var userId = GetUserId();

        var tasks = await _taskService.GetByUserAsync(userId);

        if (tasks == null || !tasks.Any())
            return NotFound(new { message = "Tasks Not Found" });

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllTasks(int id)
    {
        var tasks = await _taskService.GetByIdAsyc(id);

        if (tasks == null)
            return NotFound(new { message = "Task Not Found" });

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = GetUserId();

        var result = await _taskService.CreateAsync(userId, request);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskRequest request)
    {
        var result = await _taskService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskService.DeleteAsync(id);
        return Ok();
    }

    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        return userIdClaim == null ? throw new UnauthorizedAccessException("UserId claim missing") : Guid.Parse(userIdClaim.Value);
    }

}
