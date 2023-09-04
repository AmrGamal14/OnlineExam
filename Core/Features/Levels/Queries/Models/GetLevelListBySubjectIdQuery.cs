using Application.Bases;
using Application.Features.Levels.Queries.Results;
using Application.Features.Subjects.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Levels.Queries.Models
{
    public class GetLevelListBySubjectIdQuery : IRequest<Response<List<GetLevelListResponse>>>
    {
        public Guid SubjectId { get; set; }
    }
}
