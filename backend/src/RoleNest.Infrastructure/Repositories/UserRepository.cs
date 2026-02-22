using Microsoft.EntityFrameworkCore;
using RoleNest.Application.Interfaces.Repositories;
using RoleNest.Domain.Entities;
using RoleNest.Infrastructure.Persistence;

namespace RoleNest.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RoleNestDbContext _context;

    public UserRepository(RoleNestDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        //return await _context.Users.FindAsync(id);

        return await _context.Users
            .Include(u => u.Skills)
            .Include(u => u.JobApplications)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Skills)
            .Include(u => u.JobApplications)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

    }
}
