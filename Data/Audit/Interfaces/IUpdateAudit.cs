using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Audit.Interfaces
{
    public interface IUpdateAudit
    {
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
