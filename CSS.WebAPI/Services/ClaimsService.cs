using System.Security.Claims;
using CSS.Application.Services.Interfaces;

namespace CSS.WebAPI.Services;
public class ClaimsService : IClaimsService
{
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        // todo implementation to get the current userId
        var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("sub");
        GetCurrentUser = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
    }


    public Guid GetCurrentUser { get; }
}

