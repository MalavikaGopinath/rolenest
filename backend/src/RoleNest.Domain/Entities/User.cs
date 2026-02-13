namespace RoleNest.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Role { get; set; } = "User"; // User / Admin

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<JobApplication> JobApplications { get; set; }
        = new List<JobApplication>();

    public ICollection<Skill> Skills { get; set; }
        = new List<Skill>();
}
