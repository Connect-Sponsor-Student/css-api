using CSS.Application.Services.Interfaces;
using System.Security.Claims;

namespace CSS.WebAPI.Services;
public class ClaimsService : IClaimsService
{
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        // todo implementation to get the current userId
        var claims = httpContextAccessor.HttpContext?.User?.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);
        string? Id = claims is not null ? claims.Value : null;
        GetCurrentUser = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
    }


    public Guid GetCurrentUser { get; }
}

