
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddMappings();
        return services;

    }
}