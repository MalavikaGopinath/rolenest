using AutoMapper;
using RoleNest.Domain.Entities;
using RoleNest.Application.DTOs.Users;

namespace RoleNest.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from Entity to Response DTO
        CreateMap<User, UserResponseDto>();

        // Map from Create DTO to Entity
        CreateMap<CreateUserDto, User>();

        // Map from Update DTO to Entity
        CreateMap<UpdateUserDto, User>();
    }
}
