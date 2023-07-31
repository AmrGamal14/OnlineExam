﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Features.UserCQRS.Command.Models;
using Core.Features.UserCQRS.Query.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/ShowAllUser")]
        public async Task<IActionResult> Paginated([FromQuery] GetUserListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPost("/Register")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditUser")]
        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);   
            return Ok(response);
        }
        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(response);
        }
        [HttpPut("/ChangeUserPassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
