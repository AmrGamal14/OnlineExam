using Data.Entities.Models;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface ISkillService
    {
        public Task<Skill> GetByEnum(SkillLevel SkillEnum);
    }
}

