using Core.Features.Exams.Queries.Models;
using Core.Features.StudentHistory.Queries.Models;
using Core.Features.StudentHistory.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentHistoryController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/StudentHistory")]
        public async Task<IActionResult> GetExamList()
        {
            var response = await _mediator.Send(new GetStudentHistory());
            return Ok(response);
        }
      
        [HttpGet("/ExamHistory")]
        public async Task<IActionResult> GetExamHistory([FromQuery] GetExamHistory command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    
    }
}
