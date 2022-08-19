using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using twocount.infrastructure.Identity.Contracts;
using twocount.infrastructure.Identity.Entities;

namespace twocount.infrastructure.Identity.Services;

public class TokenService : ITokenService
{
    private readonly string _securityKey;

    public TokenService(string securityKey)
    {
        _securityKey = securityKey;
    }
    
    public (string, RefreshTokenDto) CreateTokenAndRefreshUserToken(User user)
    {
        var token = CreateToken(user);
        var refreshToken = GenerateRefreshToken();

        return (token, refreshToken);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_securityKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    
    private RefreshTokenDto GenerateRefreshToken()
    {
        var refreshToken = new RefreshTokenDto
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now
        };

        return refreshToken;
    }
}