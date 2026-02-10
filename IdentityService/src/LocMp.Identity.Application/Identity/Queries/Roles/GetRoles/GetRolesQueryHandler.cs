using AutoMapper;
using AutoMapper.QueryableExtensions;
using LocMp.Identity.Application.DTOs.Role;
using LocMp.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocMp.Identity.Application.Identity.Queries.Roles.GetRoles;

public sealed class GetRolesQueryHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper)
    : IRequestHandler<GetRolesQuery, IReadOnlyList<RoleDto>>
{
    public async Task<IReadOnlyList<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleManager.Roles
            .AsNoTracking()
            .OrderBy(r => r.Name)
            .ProjectTo<RoleDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return roles;
    }
}