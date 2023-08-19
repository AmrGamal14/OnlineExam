using Core.Bases;
using Core.Features.Answer.Queries.Result;
using Core.Features.Questions.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Queries.Models
{
    public class GetAnswerListQuery : IRequest<Response<List<GetAnswerListResponse>>>
    {
        public Guid QuestionId { get; set; }
    }
    
    
}
