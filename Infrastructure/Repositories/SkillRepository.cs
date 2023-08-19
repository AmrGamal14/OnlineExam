using Data.Entities.Models;
using Data.Enums;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SkillRepository : GenericRepositoryAsync<Skill> , ISkillRepository
    {
        private readonly DbSet<Skill> _skill;
        public SkillRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _skill= dbContext.Set<Skill>();
        }
        public async Task<Skill> GetByEnum(SkillLevel SkillName)
        {
            var skill = await _skill.FirstOrDefaultAsync(n => n.Name == SkillName);
            return skill;
        }
    }
}
