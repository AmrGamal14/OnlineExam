using Core.Bases;
using Core.Features.Levels.Queries.Results;
using Core.Features.Subjects.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Queries.Models
{
    public class GetLevelListBySubjectIdQuery : IRequest<Response<List<GetLevelListResponse>>>
    {
        public Guid SubjectId { get; set; }
    }
}
