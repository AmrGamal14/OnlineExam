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
    public class GetQuestionAndAnswerById : IRequest<Response<GetByIdResponse>>
    {
        public Guid Id { get; set; }
    }
}
