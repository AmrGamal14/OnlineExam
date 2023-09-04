using Application.Bases;
using Application.Features.Exams.Queries.Result;
using Application.Features.Subjects.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Queries.Models
{
    public class GetExamListQuery : IRequest<Response<List<GetExamListResponse>>>
    {
        public Guid LevelId { get; set; }
    }
}
