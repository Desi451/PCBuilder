using Domain.Entities;

namespace Domain.Interfaces.Common;

public interface IAuthService
{
    Task Login(User user);
    Task Register(User user);
    Task GetCurrentUser();
}
