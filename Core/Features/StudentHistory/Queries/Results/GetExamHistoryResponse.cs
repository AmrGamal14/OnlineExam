using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.StudentHistory.Queries.Results
{
    public class GetExamHistoryResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
