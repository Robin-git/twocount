using Microsoft.AspNetCore.Mvc;
using twocount.infrastructure.Identity.Contracts;
using twocount.infrastructure.Identity.Entities;
using twocount.infrastructure.Identity.Services;

namespace twocount.web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public AuthController(ILogger<AuthController> logger, IAuthenticationService _authenticationService)
    {
        this._authenticationService = _authenticationService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterUserDto request)
    {
        _logger.LogDebug("register user");
        var user = await _authenticationService.RegisterAsync(request);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginUserDto request)
    {
        var token = await _authenticationService.LoginAsync(request);
        return Ok(token);
    }
}