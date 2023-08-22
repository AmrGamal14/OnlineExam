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
        private readonly IUnitOfWork _unitOfWork;
        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public async Task<Skill> GetByEnum(SkillLevel SkillName)
        {
            var skill= await _unitOfWork.skill.GetByEnum(SkillName);
            return skill;
        }
    }
}
