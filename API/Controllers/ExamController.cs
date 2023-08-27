using Core.Features.Exams.Commands.Models;
using Core.Features.Exams.Queries.Models;
using Core.Features.Levels.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/GetTeacherExams")]
        public async Task<IActionResult> GetExamList([FromQuery] GetExamListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("/GetExamById")]
        public async Task<IActionResult> GetExamById([FromQuery] GetExamByIdQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
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
