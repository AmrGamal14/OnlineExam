using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class StudentExamForm
    {
        public DateTime ExamDate { get; set; }
        public Guid ExamId { get; set; }
        public Guid UserId { get; set; }
    }
}

