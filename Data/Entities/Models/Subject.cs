using Data.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Subject :  BaseEntityAudit<Guid>
    {
        public string Name { get; set; }
        public HashSet<SubjectLevel> SubjectLevels { get; set; }

    }
}
