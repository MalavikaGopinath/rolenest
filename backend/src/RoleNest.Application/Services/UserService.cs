using RoleNest.Application.DTOs.Users;
using RoleNest.Application.Interfaces.Repositories;
using RoleNest.Application.Interfaces.Services;
using RoleNest.Domain.Entities;
using RoleNest.Domain.Exceptions;
using AutoMapper;

namespace RoleNest.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException($"User with Id {id} was not found.");
        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        await _userRepository.AddAsync(user);

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task UpdateAsync(Guid id, UpdateUserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException($"User with Id {id} was not found.");

        _mapper.Map(userDto, user);

        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException($"User with Id {id} was not found.");
        await _userRepository.DeleteAsync(user);
    }
}
