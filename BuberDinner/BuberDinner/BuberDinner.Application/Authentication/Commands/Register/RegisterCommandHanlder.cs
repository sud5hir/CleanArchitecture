using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{

    public class RegisterCommandHanlder : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtToekenGenerator _iJwtToekenGenerator;
        private IUserRepository _iUserRepository;

        public RegisterCommandHanlder(IJwtToekenGenerator iJwtToekenGenerator, IUserRepository iUserRepository, IJwtToekenGenerator iJwtToekenGenerator2)
        {
            _iJwtToekenGenerator = iJwtToekenGenerator;
            _iUserRepository = iUserRepository;
            _iJwtToekenGenerator = iJwtToekenGenerator2;
        }


        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_iUserRepository.GetUserByEmail(request.Email) != null)
            {
                throw new Exception("User already exist");
            }
            //Guid userId = Guid.NewGuid();

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                Lastname = request.LastName,
                Password = request.Password,
                Email = request.Email
            };

            _iUserRepository.Add(user);
            var token = _iJwtToekenGenerator.GenerateToken(user.Id, request.FirstName, request.LastName);

            return new AuthenticationResult(user.Id, request.FirstName, request.LastName, request.Email, token);
        }
    }
}