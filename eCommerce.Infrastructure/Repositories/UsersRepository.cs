using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryInterfaces;

namespace eCommerce.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        var user = new ApplicationUser 
        {
            UserID = Guid.NewGuid(),
            Email = email,
            Password = password,
            Name = "Mocked User Name",
            Gender = GenderOptions.Male.ToString()
        };

        return user;
    }
}
