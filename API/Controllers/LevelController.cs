using Core.Features.Levels.Commands.Models;
using Core.Features.Levels.Queries.Models;
using Core.Features.Subjects.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LevelController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/GetAllLevels")]
        public async Task<IActionResult> GetLevelListBySubjectID([FromQuery] GetLevelListBySubjectIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("/CreateLevel")]
        public async Task<IActionResult> Create([FromBody] AddLevelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/EditLevel")]
        public async Task<IActionResult> Edit([FromBody] EditLevelCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/Deletelevel")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteLevelCommand(id));
            return Ok(response);
        }
    }
}
