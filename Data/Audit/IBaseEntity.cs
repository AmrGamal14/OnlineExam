﻿using Data.Audit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Audit
{
    public class BaseEntityAudit<T> : BaseEntity<T> , ICreateAudit, IUpdateAudit
    {
         public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
         public string CreatedBy { get; set; }
         public DateTime? UpdatedDate { get; set; }
         public string UpdatedBy { get; set; }
    }
    public class BaseEntity<T> : IBaseEntity
    {
        public string Id { get; set; }
    }
    public interface IBaseEntity
    {
    }
}
