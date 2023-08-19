using Core.Features.Levels.Queries.Models;
using Core.Features.Subjects.Commands.Models;
using Core.Features.Subjects.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/ShowAllSubject")]
        public async Task<IActionResult> GetSubjectList()
        {
            var response = await _mediator.Send(new GetSubjectListQuery());
            return Ok(response);
        }
        [HttpPost("/CreateSubject")]
        public async Task<IActionResult> Create([FromBody] AddSubjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditSubject")]
        public async Task<IActionResult> Edit([FromBody] EditSubjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/DeleteSubject")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteSubjectCommand(id));
            return Ok(response);
        }

    }
}
