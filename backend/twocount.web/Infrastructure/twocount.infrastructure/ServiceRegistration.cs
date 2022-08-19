using Microsoft.Extensions.DependencyInjection;
using twocount.infrastructure.Core.Config;
using twocount.infrastructure.Identity.Repositories;
using twocount.infrastructure.Identity.Services;

namespace twocount.infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, InfrastructureConfig config)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITokenService>(x => new TokenService(config.SecurityKey));
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
}