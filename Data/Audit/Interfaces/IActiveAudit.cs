using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Audit.Interfaces
{
    public interface IActiveAudit
    {
        bool? IsActive { get; set; }
    }
}
