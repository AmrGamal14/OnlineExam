using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class SubjectLevel : BaseEntityAudit<Guid>
    {
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public HashSet<Exam> Exams { get; set; }
        public HashSet<Question> Questions{ get; set; }

    }
}
