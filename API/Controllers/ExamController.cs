using Core.Features.Exams.Commands.Models;
using Core.Features.Levels.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("/CreateExam")]
        public async Task<IActionResult> Create([FromBody] AddExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditExam")]
        public async Task<IActionResult> Edit([FromBody] EditExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/DeleteExam")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteExamCommand(id));
            return Ok(response);
        }
    }
}
