
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtToekenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        IServiceCollection serviceCollection = services.AddScoped<IUserRepository, UserRepository>();
        return services;

    }
}