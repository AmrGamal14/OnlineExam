using API.ControllersBase;
using Application.Features.Levels.Queries.Models;
using Application.Features.Subjects.Commands.Models;
using Application.Features.Subjects.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : AppControllerBase
    {
        [HttpGet("/ShowAllSubject")]
        public async Task<IActionResult> GetSubjectList()
        {
            var response = await _mediator.Send(new GetSubjectListQuery());
            return NewResult(response);
        }
        [HttpPost("/CreateSubject")]
        public async Task<IActionResult> Create([FromBody] AddSubjectCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditSubject")]
        public async Task<IActionResult> Edit([FromBody] EditSubjectCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("/DeleteSubject")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteSubjectCommand(id));
            return NewResult(response);
        }

    }
}
