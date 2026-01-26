using Microsoft.AspNetCore.Identity;

namespace LocMp.Identity.Domain.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public bool Active { get; set; } = true;
}