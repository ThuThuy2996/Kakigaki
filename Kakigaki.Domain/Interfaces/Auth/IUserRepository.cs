using Kakigaki.Domain.Entities;

namespace Kakigaki.Domain.Interfaces.Auth
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByGoogleIdAsync(string googleId);
        Task AddAsync(User user);
    }
}
