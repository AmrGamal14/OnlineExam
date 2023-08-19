using Core.Bases;
using Core.Features.Questions.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Queries.Models
{
    public class GetQuestionRandom : IRequest<Response<List<GetQuestionRandomResponse>>>
    {
        public Guid ExamId { get; set; }

    }
}
