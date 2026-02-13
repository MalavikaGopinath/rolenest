namespace RoleNest.Domain.Entities;

public class Skill
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;
    // e.g. C#, React, Azure

    public int ProficiencyLevel { get; set; }
    // 1–5 scale

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public User User { get; set; } = default!;
}
