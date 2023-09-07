using API.ControllersBase;
using Application.Features.Answer.Command.Models;
using Application.Features.Answer.Queries.Models;
using Application.Features.Levels.Queries.Models;
using Application.Features.Questions.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : AppControllerBase
    {
      
        [HttpGet("/GetQuestionAnswers")]
        public async Task<IActionResult> GetAnswerListByQuestionID([FromQuery] GetAnswerListQuery request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpGet("/GetAnswerById")]
        public async Task<IActionResult> GetAnswerById([FromQuery] GetAnswerById request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpPost("/AddAnswer")]
        public async Task<IActionResult> Create([FromBody] AddAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        } 
        [HttpPost("/AnswersCorrection")]
        public async Task<IActionResult> Correct([FromBody] CorrectionAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditAnswer")]
        public async Task<IActionResult> Edit([FromBody] EditAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("/DeleteAnswer")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteAnswerCommand(id));
            return NewResult(response);
        }
    }
}
