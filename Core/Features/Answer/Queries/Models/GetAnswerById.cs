using Application.Bases;
using Application.Features.Answer.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Answer.Queries.Models
{
    public class GetAnswerById : IRequest<Response<GetAnswerByIdResponse>>
    {
        public Guid AnswerId { get; set; }
    }
}
