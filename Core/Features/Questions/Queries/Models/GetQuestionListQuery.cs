using Core.Bases;
using Core.Features.Levels.Queries.Results;
using Core.Features.Questions.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Queries.Models
{
    public class GetQuestionListQuery : IRequest<Response<List<GetQuestionListResponse>>>
    {
        public Guid LevelId { get; set; }
    }
}
