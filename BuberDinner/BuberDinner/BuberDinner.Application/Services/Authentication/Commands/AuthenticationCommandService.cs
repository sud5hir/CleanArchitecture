
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Domain;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;

namespace BuberDinner.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtToekenGenerator _iJwtToekenGenerator;
        private IUserRepository _iUserRepository;

        public AuthenticationCommandService(IJwtToekenGenerator iJwtToekenGenerator, IUserRepository iUserRepository, IJwtToekenGenerator iJwtToekenGenerator2)
        {
            _iJwtToekenGenerator = iJwtToekenGenerator;
            _iUserRepository = iUserRepository;
            _iJwtToekenGenerator = iJwtToekenGenerator2;
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            if (_iUserRepository.GetUserByEmail(Email) != null)
            {
                throw new Exception("User already exist");
            }
            //Guid userId = Guid.NewGuid();

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                Lastname = LastName,
                Password = Password,
                Email = Email
            };

            _iUserRepository.Add(user);
            var token = _iJwtToekenGenerator.GenerateToken(user.Id, FirstName, LastName);

            return new AuthenticationResult(user.Id, FirstName, LastName, Email, token);
        }


    }
}