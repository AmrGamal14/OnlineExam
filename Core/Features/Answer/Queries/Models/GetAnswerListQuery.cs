using Application.Bases;
using Application.Features.Answer.Queries.Result;
using Application.Features.Questions.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Answer.Queries.Models
{
    public class GetAnswerListQuery : IRequest<Response<List<GetAnswerListResponse>>>
    {
        public Guid QuestionId { get; set; }
    }
    
    
}
