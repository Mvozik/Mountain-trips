
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Dtos;
using WycieczkiGórskie.Shared.Entities;

namespace WycieczkiGórskie.Shared.Services.IServices
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserPostRegistrationDto request);
        Task<AuthenticationResult> LoginAsync(UserPostLoginDto request);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<AuthenticationResult> LogoutAsync(string refreshToken);

    }
}
