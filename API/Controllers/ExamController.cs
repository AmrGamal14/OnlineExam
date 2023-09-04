using API.ControllersBase;
using Application.Features.Exams.Commands.Models;
using Application.Features.Exams.Queries.Models;
using Application.Features.Levels.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamController : AppControllerBase
    {
        
        [HttpGet("/GetTeacherExams")]
        public async Task<IActionResult> GetExamList([FromQuery] GetExamListQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet("/GetExamById")]
        public async Task<IActionResult> GetExamById([FromQuery] GetExamByIdQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost("/CreateExam")]
        public async Task<IActionResult> Create([FromBody] AddExamCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditExam")]
        public async Task<IActionResult> Edit([FromBody] EditExamCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("/DeleteExam")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteExamCommand(id));
            return Ok(response);
        }
    }
}
