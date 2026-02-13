using RoleNest.Domain.Entities;

namespace RoleNest.Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
