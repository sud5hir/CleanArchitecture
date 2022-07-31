
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtToekenGenerator _iJwtToekenGenerator;
        private IUserRepository _iUserRepository;

        public LoginQueryHandler(IJwtToekenGenerator iJwtToekenGenerator, IUserRepository iUserRepository, IUserRepository iUserRepository2)
        {
            _iJwtToekenGenerator = iJwtToekenGenerator;
            _iUserRepository = iUserRepository;
            _iUserRepository = iUserRepository2;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (_iUserRepository.GetUserByEmail(request.Email) is not User user1)
            {
                throw new Exception("User doesnot exist");
            }


            if (user1.Password != request.Password)
            {
                throw new Exception("password invalid");
            }

            var token = _iJwtToekenGenerator.GenerateToken(user1.Id, user1.FirstName, user1.Lastname);

            return new AuthenticationResult(user1.Id, user1.FirstName, user1.Lastname, request.Email, token);
        }
    }
}


