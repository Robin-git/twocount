namespace twocount.infrastructure.Identity.Contracts;

public class RefreshTokenDto
{
    public string Token { get; init; } = string.Empty;
    public DateTime Created { get; init; } = DateTime.Now;
    public DateTime Expires { get; init; }
}