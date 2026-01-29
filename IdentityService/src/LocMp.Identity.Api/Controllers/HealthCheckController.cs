using Duende.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocMp.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    // [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [HttpGet]
    public IActionResult Get() => Ok();
}