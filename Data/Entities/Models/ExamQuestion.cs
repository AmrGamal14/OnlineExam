using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class ExamQuestion :  BaseEntityAudit<Guid>
    {
       
        public Guid StudentExamId { get; set; }
        public StudentExam StudentExam { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question {get; set; }
    }
}
