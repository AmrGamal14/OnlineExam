using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class StudentExamResult :  BaseEntityAudit<Guid>
    {
        
        public Guid StudentExamId { get; set; }
        public StudentExam StudentExam { get; set; }
        public Guid AnswerId { get; set; }
        public Answers Answer { get; set; }
        public bool IsCorrect { get; set; } 



    }
}
