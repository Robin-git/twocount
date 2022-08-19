using twocount.infrastructure.Identity.Contracts;
using twocount.infrastructure.Identity.Entities;

namespace twocount.infrastructure.Identity.Services;

public interface ITokenService
{
    (string, RefreshTokenDto) CreateTokenAndRefreshUserToken(User user);
}