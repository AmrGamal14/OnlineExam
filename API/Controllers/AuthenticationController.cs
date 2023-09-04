using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Authentication.Command.Models;
using Application.Features.Authentication.Queries.Models;
using API.ControllersBase;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
      
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);

        }
        [HttpPost("/RefreshToken")]
        public async Task <IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);

        }
    }
}
