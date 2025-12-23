using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    // POST: api/tasks
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request)
    {
        // Temporary userId (will come from JWT later)
        var userId = GetUserId();

        var result = await _taskService.CreateAsync(userId, request);
        return Ok(result);
    }

    // GET: api/tasks
    [Authorize(Policy = "AdminOnly")]
    [HttpGet]
    public async Task<IActionResult> GetMyTasks()
    {
        // Temporary userId
        var userId = Guid.NewGuid();

        var tasks = await _taskService.GetByUserAsync(userId);
        return Ok(tasks);
    }   

    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);

        if (userIdClaim == null)
            throw new UnauthorizedAccessException("UserId claim missing");

        return Guid.Parse(userIdClaim.Value);
    }

}
