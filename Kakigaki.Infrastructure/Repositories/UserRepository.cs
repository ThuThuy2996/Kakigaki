using AutoMapper;
using Kakigaki.Domain.Entities;
using Kakigaki.Domain.Interfaces.Auth;
using Kakigaki.Infrastructure.Data;
using Kakigaki.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kakigaki.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(User user)
        {
            var userModel = _mapper.Map<user>(user);
            await _context.users.AddAsync(userModel);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(o => o.email.Equals(email));
            return _mapper.Map<User>(user);
        }

        public Task<User?> GetByGoogleIdAsync(string googleId)
        {
            throw new NotImplementedException();
        }
    }
}
