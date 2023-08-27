using Core.Bases;
using Core.Features.StudentHistory.Queries.Results;
using Core.Features.Subjects.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.StudentHistory.Queries.Models
{
    public class GetStudentHistory : IRequest<Response<List<GetStudentHistoryResponse>>>
    {
    }
}
