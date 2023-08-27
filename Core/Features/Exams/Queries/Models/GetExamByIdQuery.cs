using Core.Bases;
using Core.Features.Exams.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Exams.Queries.Models
{
    public class GetExamByIdQuery : IRequest<Response<GetExamResponse>>
    {
        public Guid Id { get; set; }
    }
}
