using BuberDinner.Application.Services.Authentication.Common;
namespace BuberDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
}