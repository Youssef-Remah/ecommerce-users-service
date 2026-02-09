using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryInterfaces;
using eCommerce.Core.ServiceInterfaces;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AuthenticationResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _usersRepository.GetUserByEmailAndPasswordAsync(request.Email, request.Password);

        if (user == null) return null;

        return new AuthenticationResponse (
            user.UserID,
            user.Email,
            user.Gender,
            user.Name,
            "token",
            true
        );
    }

    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Gender = request.Gender.ToString()
        };

        var registeredUser = await _usersRepository.AddUserAsync(user);

        if(registeredUser == null) return null;

        return new AuthenticationResponse(
            registeredUser.UserID,
            registeredUser.Email,
            registeredUser.Name,
            registeredUser.Gender,
            "token",
            true
        );
    }
}
