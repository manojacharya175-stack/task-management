using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public string Role { get; private set; } = "User";

    private User() { }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
}
