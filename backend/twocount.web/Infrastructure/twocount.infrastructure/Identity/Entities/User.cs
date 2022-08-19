namespace twocount.infrastructure.Identity.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Username { get; init; } = "";
    public byte[] PasswordHash { get; init; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; init; } = Array.Empty<byte>();
    public string RefreshToken { get; private set; } = "";
    public DateTime TokenCreated { get; private set; } = DateTime.Now;
    public DateTime? TokenExpires { get; private set; } = null;

    public void SetRefreshToken(string refreshToken, DateTime tokenCreated, DateTime tokenExpires)
    {
        RefreshToken = refreshToken;
        TokenCreated = tokenCreated;
        TokenExpires = tokenExpires;
    }
}