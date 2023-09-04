using Application.Bases;
using Application.Features.Levels.Queries.Results;
using Application.Features.Questions.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.Models
{
    public class GetQuestionListQuery : IRequest<Response<List<GetQuestionListResponse>>>
    {
        public Guid LevelId { get; set; }
    }
}
