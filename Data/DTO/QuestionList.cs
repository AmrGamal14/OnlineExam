using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class QuestionList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public Guid SubjectLevelId { get; set; }
        public Guid SkillId { get; set; }
    }
}
