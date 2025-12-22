using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; }
    public string Name { get; private set; }

    private User() { }

    public User(string email, string name)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        Email = email;
        Name = name;
    }
}
