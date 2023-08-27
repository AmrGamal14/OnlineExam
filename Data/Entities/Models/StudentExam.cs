using Data.Audit;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class StudentExam :  BaseEntityAudit<Guid>
    {
     
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<StudentExamResult> StudentExamResults { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
