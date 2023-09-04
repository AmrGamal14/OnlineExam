using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Queries.Result
{
    public class GetExamListResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public int Duration { get; set; }
        public Uri? url { get; set; }
    }
}
