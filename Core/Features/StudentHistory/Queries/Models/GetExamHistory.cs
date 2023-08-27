using Core.Bases;
using Core.Features.StudentHistory.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.StudentHistory.Queries.Models
{
    public class GetExamHistory : IRequest<Response<List<GetExamHistoryResponse>>>
    {
       public Guid ExamId { get; set; }
    }
}
