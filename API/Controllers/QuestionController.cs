using Core.Features.Questions.Commands.Models;
using Core.Features.Questions.Queries.Models;
using Core.Features.Subjects.Commands.Models;
using Core.Features.Subjects.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/ShowAllQuestion")]
        public async Task<IActionResult> GetQuestionList([FromQuery] GetQuestionListQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("/ExamQuestion")]
        public async Task<IActionResult> GetQuestionRandom([FromQuery] GetQuestionRandom request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("/CreateQuestion")]
        public async Task<IActionResult> Create([FromBody] AddQuestionAndAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditQuestion")]
        public async Task<IActionResult> Edit([FromBody] EditQuestionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/DeleteQuestion")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteQuestionCommand(id));
            return Ok(response);
        }
    }
}
