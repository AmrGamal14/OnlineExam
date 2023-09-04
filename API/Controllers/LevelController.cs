using API.ControllersBase;
using Application.Features.Levels.Commands.Models;
using Application.Features.Levels.Queries.Models;
using Application.Features.Subjects.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : AppControllerBase
    {
       
        [HttpGet("/GetAllLevels")]
        public async Task<IActionResult> GetLevelListBySubjectID([FromQuery] GetLevelListBySubjectIdQuery request)
        {
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
        [HttpPost("/CreateLevel")]
        public async Task<IActionResult> Create([FromBody] AddLevelCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("/EditLevel")]
        public async Task<IActionResult> Edit([FromBody] EditLevelCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("/Deletelevel")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new DeleteLevelCommand(id));
            return NewResult(response);
        }
    }
}
