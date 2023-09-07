using Application.Bases;
using Application.Features.StudentHistory.Queries.Results;
using Application.Features.Subjects.Queries.Result;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Queries.Models
{
    public class GetStudentHistory : IRequest<PaginatedResult<GetStudentHistoryResponse>> /* : IRequest<Response<List<GetStudentHistoryResponse>>>*/
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
