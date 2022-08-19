using Dapper;
using Microsoft.Extensions.Configuration;
using twocount.infrastructure.Core.Repositories;
using twocount.infrastructure.Identity.Entities;

namespace twocount.infrastructure.Identity.Repositories;

public class UserRepository : DbConnector, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<User?> GetAsync(string username)
    {
        using var conn = CreateConnection();
        
        var query = @"SELECT * FROM users WHERE username = @Username;";

        return await conn.QuerySingleOrDefaultAsync<User>(query, new
        {
            Username = username,
        });
    }

    public async Task<User> AddAsync(User user)
    {
        using var conn = CreateConnection();
        
        var insertSql = @"INSERT INTO users(username, password_hash, password_salt)
                          VALUES(@Username, @PasswordHash, @PasswordSalt)
                          RETURNING *;";

        return await conn.QuerySingleAsync<User>(insertSql, new
        {
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt
        });
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }
    
    public async Task UpdateRefreshTokenAsync(User user)
    {
        using var conn = CreateConnection();

        var query = @"UPDATE users 
                      SET refresh_token = @RefreshToken,
                          token_created = @TokenCreated,
                          token_expires = @TokenExpires
                      WHERE id = @Id;";

        await conn.ExecuteAsync(query, new
        {
            RefreshToken = user.RefreshToken,
            TokenCreated = user.TokenCreated,
            TokenExpires = user.TokenExpires,
            Id = user.Id
        });
    }
}