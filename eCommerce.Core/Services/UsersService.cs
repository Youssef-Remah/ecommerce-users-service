using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryInterfaces;
using eCommerce.Core.ServiceInterfaces;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _usersRepository.GetUserByEmailAndPasswordAsync(request.Email, request.Password);

        if (user == null) return null;

        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
    }

    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest request)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        var registeredUser = await _usersRepository.AddUserAsync(user);

        if(registeredUser == null) return null;

        return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}
