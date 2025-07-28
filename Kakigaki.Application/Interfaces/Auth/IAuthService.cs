using Kakigaki.Application.DTOs.Auth;
using System.Threading.Tasks;

namespace Kakigaki.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterWithGoogleAsync(GoogleRegisterRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
