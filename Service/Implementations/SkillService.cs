using Data.Entities.Models;
using Data.Enums;
using Infrastructure.Abstracts;
using Infrastructure.Repositories;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService ( ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> GetByEnum(SkillLevel SkillName)
        {
            var skill= await _skillRepository.GetByEnum(SkillName);
            return skill;
        }
    }
}
