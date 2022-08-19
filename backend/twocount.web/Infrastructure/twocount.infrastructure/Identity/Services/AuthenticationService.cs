using System.Security.Cryptography;
using twocount.infrastructure.Identity.Contracts;
using twocount.infrastructure.Identity.Entities;
using twocount.infrastructure.Identity.Exceptions;
using twocount.infrastructure.Identity.Repositories;

namespace twocount.infrastructure.Identity.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<User> RegisterAsync(RegisterUserDto request)
    {
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(user);

        return user;
    }
    
    public async Task<string> LoginAsync(LoginUserDto request)
    {
        var user = await _userRepository.GetAsync(request.Username);
        
        if (user == null)
        {
            throw new CannotLoginException();
        }

        if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new CannotLoginException();
        }

        var (token, refreshToken) = _tokenService.CreateTokenAndRefreshUserToken(user);
        user.SetRefreshToken(refreshToken.Token, refreshToken.Created, refreshToken.Expires);
        await _userRepository.UpdateRefreshTokenAsync(user);
        
        return token;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
        
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
        
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}