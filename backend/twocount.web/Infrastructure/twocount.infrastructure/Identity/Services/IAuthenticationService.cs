using twocount.infrastructure.Identity.Contracts;
using twocount.infrastructure.Identity.Entities;

namespace twocount.infrastructure.Identity.Services;

public interface IAuthenticationService
{ 
    Task<User> RegisterAsync(RegisterUserDto user);
    Task<string> LoginAsync(LoginUserDto user);
}