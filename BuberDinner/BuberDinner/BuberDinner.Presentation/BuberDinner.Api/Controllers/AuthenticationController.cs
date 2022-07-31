using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Presentation.BuberDinner.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using BuberDinner.Application.Authentication.Commands.Register;
using System.Threading.Tasks;
using MediatR;

namespace BuberDinner.Presentation.BuberDinner.Api.Controllers
{
    [ApiController]
    //[ErrorFilters]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        private readonly IAuthenticationQueryService _iAuthenticationQueryService;
        private readonly IAuthenticationCommandService _iAuthenticationCommandService;

        public AuthenticationController(IAuthenticationCommandService iAuthenticationCommandService, IAuthenticationQueryService iAuthenticationQueryService, ISender mediator, IMapper mapper)
        {
            _iAuthenticationCommandService = iAuthenticationCommandService;
            _iAuthenticationQueryService = iAuthenticationQueryService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            // var authResult = _iAuthenticationCommandService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);
            var command = _mapper.map<RegisterCommand>(registerRequest);

            var authResult = await _mediator.Send(command);

            var response = _mapper.map<AuthenticationResponse>(authResult);

            //     var response = new AuthenticationResponse(
            //                authResult.Id,
            //         authResult.FirstName,
            //         authResult.LastName,
            //         authResult.Email,
            //         authResult.Token
            //    );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            //     var query = new LoginQuery(
            // registerRequest.Email,
            // registerRequest.Password);

            var query = _mapper.map<LoginQuery>(loginRequest);
            // var authResult = _iAuthenticationQueryService.Login(loginRequest.Email, loginRequest.Password);
            var authResult = await _mediator.Send(query);
            var response = _mapper.map<AuthenticationResponse>(authResult);
            // var response = new AuthenticationResponse(
            //             authResult.Id,
            //     authResult.FirstName,
            //     authResult.LastName,
            //     authResult.Email,
            //     authResult.Token
            // );
            return Ok(response);
        }

    }

}
