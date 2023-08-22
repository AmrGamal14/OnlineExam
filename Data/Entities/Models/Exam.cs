using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Exam :  BaseEntityAudit<Guid>
    {
        
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public TimeSpan Duration { get; set; }
        public Uri? url { get; set; }
        public Guid SubjectLevelId { get; set; }
        public SubjectLevel SubjectLevel { get; set; }
        public HashSet<StudentExam> studentExams { get; set; }
    }
}
