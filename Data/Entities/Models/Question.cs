using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Question :  BaseEntityAudit<Guid>
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public Guid SubjectLevelId { get; set; }
        public SubjectLevel SubjectLevel { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public List<Answers> Answers { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }



    }
}
