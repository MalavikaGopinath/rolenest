using Microsoft.EntityFrameworkCore;
using RoleNest.Domain.Entities;

namespace RoleNest.Infrastructure.Persistence;

public class RoleNestDbContext : DbContext
{
    public RoleNestDbContext(DbContextOptions<RoleNestDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<Skill> Skills => Set<Skill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.JobApplications)
            .WithOne(j => j.User)
            .HasForeignKey(j => j.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);
    }
}
