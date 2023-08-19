using Data.Entities.Models;
using Data.Enums;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface ISkillRepository : IGenericeRepositoryAsync<Skill>
    {
        public  Task<Skill> GetByEnum(SkillLevel SkillName);
    }
}
