using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryInterfaces;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
}
