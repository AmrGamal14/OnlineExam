using Core.Features.Answer.Command.Models;
using Core.Features.Answer.Queries.Models;
using Core.Features.Levels.Queries.Models;
using Core.Features.Questions.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswerController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/ShowAllAnswer")]
        public async Task<IActionResult> GetAnswerListByQuestionID([FromQuery] GetAnswerListQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("/AddAnswer")]
        public async Task<IActionResult> Create([FromBody] AddAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditAnswer")]
        public async Task<IActionResult> Edit([FromBody] EditAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/DeleteAnswer")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteAnswerCommand(id));
            return Ok(response);
        }
    }
}
