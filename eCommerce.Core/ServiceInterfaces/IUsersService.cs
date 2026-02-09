using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceInterfaces;

public interface IUsersService
{
    Task<AuthenticationResponse?> LoginAsync(LoginRequest request);

    Task<AuthenticationResponse?> RegisterAsync(RegisterRequest request);
}
