namespace RoleNest.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string CompanyName { get; set; } = default!;

    public string Role { get; set; } = default!;

    public string Location { get; set; } = default!;

    public string Status { get; set; } = "Applied";
    // Applied, Interview, Offer, Rejected

    public DateTime AppliedOn { get; set; }

    public string? Notes { get; set; }

    // Navigation
    public User User { get; set; } = default!;
}
