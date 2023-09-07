using API.ControllersBase;
using Application.Features.Exams.Queries.Models;
using Application.Features.StudentHistory.Queries.Models;
using Application.Features.StudentHistory.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HistoryController : AppControllerBase
    {

        //[HttpGet("/StudentHistory")]
        //public async Task<IActionResult> GetExamList()
        //{
        //    var response = await _mediator.Send(new GetStudentHistory());
        //    return Ok(response);
         
    [HttpGet("/StudentHistory")]
    public async Task<IActionResult> GetExamList([FromQuery] GetStudentHistory command )
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("/ExamHistory")]
        public async Task<IActionResult> GetExamHistory([FromQuery] GetExamHistory command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet("/StudentQuestionsHistory")]
        public async Task<IActionResult> GetStudentQuestionsHistory([FromQuery] GetStudentQuestionHistory command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    
    }
}
