using Data.Audit;
using Data.Enums;

namespace Data.Entities.Models
{ 
    public class Skill :  BaseEntityAudit<Guid>
    {       
        public SkillLevel Name { get; set; }
        public HashSet<Question> Questions { get; set; }
    }
}
