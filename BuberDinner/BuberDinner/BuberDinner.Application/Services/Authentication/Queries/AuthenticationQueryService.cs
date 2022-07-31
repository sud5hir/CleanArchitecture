using BuberDinner.Domain;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtToekenGenerator _iJwtToekenGenerator;
    private IUserRepository _iUserRepository;

    public AuthenticationQueryService(IJwtToekenGenerator iJwtToekenGenerator, IUserRepository iUserRepository)
    {
        _iJwtToekenGenerator = iJwtToekenGenerator;
        _iUserRepository = iUserRepository;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        if (_iUserRepository.GetUserByEmail(Email) is not User user1)
        {
            throw new Exception("User doesnot exist");
        }


        if (user1.Password != Password)
        {
            throw new Exception("password invalid");
        }

        var token = _iJwtToekenGenerator.GenerateToken(user1.Id, user1.FirstName, user1.Lastname);

        return new AuthenticationResult(user1.Id, user1.FirstName, user1.Lastname, Email, token);
    }
}
