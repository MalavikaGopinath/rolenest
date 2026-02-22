using RoleNest.Application.DTOs.Users;
using RoleNest.Domain.Entities;

namespace RoleNest.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto> CreateAsync(CreateUserDto user);
    Task UpdateAsync(Guid id, UpdateUserDto user);
    Task DeleteAsync(Guid id);
}
