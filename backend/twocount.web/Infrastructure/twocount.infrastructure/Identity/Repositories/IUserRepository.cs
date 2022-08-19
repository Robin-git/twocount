using twocount.infrastructure.Identity.Entities;

namespace twocount.infrastructure.Identity.Repositories;

public interface IUserRepository
{
    Task<User?> GetAsync(string username);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task UpdateRefreshTokenAsync(User user);
}