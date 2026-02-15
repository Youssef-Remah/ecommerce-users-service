using eCommerce.Core.ServiceInterfaces;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services) 
    {
        services.AddTransient<IUsersService, UsersService>();

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}
