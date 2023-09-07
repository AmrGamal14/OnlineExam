using API.ControllersBase;
using Application.Features.Questions.Commands.Models;
using Application.Features.Questions.Queries.Models;
using Application.Features.Subjects.Commands.Models;
using Application.Features.Subjects.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : AppControllerBase
    {
        
        [HttpGet("/ShowAllQuestions")]
        
        public async Task<IActionResult> GetQuestionList([FromQuery] GetQuestionListQuery request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpGet("/ExamQuestions")]
        public async Task<IActionResult> GetQuestionRandom([FromQuery] GetQuestionRandom request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpGet("/GetQuestionById")]
        public async Task<IActionResult> GetQuestionById([FromQuery] GetQuestionAndAnswerById request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpPost("/CreateQuestion")]
        public async Task<IActionResult> Create([FromBody] AddQuestionAndAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditQuestionAndAnswer")]
        public async Task<IActionResult> Edit([FromBody] EditQuestionAndAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditQuestion")]
        public async Task<IActionResult> Update([FromBody] EditQuestionCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("/DeleteQuestion")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteQuestionCommand(id));
            return NewResult(response);
        }
    }
}
