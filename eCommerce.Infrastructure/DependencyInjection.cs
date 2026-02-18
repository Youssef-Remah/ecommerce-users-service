using eCommerce.Core.RepositoryInterfaces;
using eCommerce.Infrastructure.AppConfigurations;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();

        services.AddTransient<DapperDbContext>();

        services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

        return services;
    }
}
