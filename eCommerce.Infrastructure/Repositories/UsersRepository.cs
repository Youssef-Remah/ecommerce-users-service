using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryInterfaces;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    
    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        string query = """
            Insert INTO public."Users"("UserID", "Email", "Name", "Gender", "Password")
            VALUES(@UserID, @Email, @Name, @Gender, @Password)
            """;

        int rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        return rowsAffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        string query = """
            SELECT * FROM public."Users"
            WHERE "Email"=@Email AND "Password"=@Password
            """;
        
        var parameters = new {Email = email, Password = password};
        
        var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }
}
