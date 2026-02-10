using AutoMapper;
using LocMp.Identity.Application.DTOs.Role;
using LocMp.Identity.Application.DTOs.User;
using LocMp.Identity.Domain.Entities;

namespace LocMp.Identity.Application.Mapping;

public sealed class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<ApplicationRole, RoleDto>();
    }
}

