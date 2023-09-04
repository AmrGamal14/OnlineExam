using Application.Bases;
using Application.Features.StudentHistory.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Queries.Models
{
    public class GetStudentQuestionHistory : IRequest<Response<List<GetStudentQuestionHistoryResponse>>>
    {
        public Guid ExamId { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
