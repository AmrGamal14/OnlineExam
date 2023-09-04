using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.UserCQRS.Command.Models;
using Application.Features.UserCQRS.Query.Models;
using Application.Resources;
using Microsoft.Extensions.Localization;
using API.ControllersBase;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        
        [HttpGet("/ShowAllUser")]
        public async Task<IActionResult> Paginated([FromQuery] GetUserListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPost("/Registeration")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditUser")]
        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);   
            return NewResult(response);
        }
        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
        [HttpPut("/ChangeUserPassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
