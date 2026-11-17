using System.Security.Claims;
using Application.Interfaces;
using Application.Service.Common;
using Domain.Common;

namespace WebAPI.Security;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int Id
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(value, out var userId))
            {
                throw new UnauthorizedException("Invalid user identity.");
            }

            return userId;
        }
    }

    public bool IsAdminOrAbove
    {
        get
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user is not null && (user.IsInRole(Roles.Admin) || user.IsInRole(Roles.HeadAdmin));
        }
    }
}
