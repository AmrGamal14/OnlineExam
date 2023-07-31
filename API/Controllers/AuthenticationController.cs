using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Features.Authentication.Command.Models;
using Core.Features.Authentication.Queries.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpPost("/RefreshToken")]
        public async Task <IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok (response);
        }
        [HttpGet]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
