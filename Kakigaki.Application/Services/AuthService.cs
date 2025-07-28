using AutoMapper;
using Kakigaki.Application.DTOs.Auth;
using Kakigaki.Application.Interfaces.Auth;
using Kakigaki.Domain.Entities;
using Kakigaki.Domain.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;

namespace Kakigaki.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            var test = request.GetType().FullName;

            var user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.AddAsync(user);

            return _mapper.Map<AuthResponse>(user);
        }

        public Task<AuthResponse> RegisterWithGoogleAsync(GoogleRegisterRequest request)
        {
            throw new NotImplementedException();
        }
      
    }
}
