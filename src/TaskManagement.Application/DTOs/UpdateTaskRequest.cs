using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Application.DTOs;

public record UpdateTaskRequest(string Title, bool Status, Guid UserId);
