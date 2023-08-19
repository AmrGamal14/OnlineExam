using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAuditService
    {
        string UserName { get; }
        string UserId { get; }
        string UserType { get; }
    }
}
