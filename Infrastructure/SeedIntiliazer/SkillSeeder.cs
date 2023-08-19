using Data.Entities.Identity;
using Data.Entities.Models;
using Data.Enums;
using Infrastructure.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedIntiliazer
{
    public static class SkillSeeder
    {
        public static async Task SeedAsync(ISkillRepository _skillRepository)
        {
            var Skills = await _skillRepository.GetAll();
            if (Skills.Count == 0)
            {
                await _skillRepository.AddAsync(new Skill()
                {
                    Name= SkillLevel.Easy
                });
                await _skillRepository.AddAsync(new Skill()
                {
                    Name= SkillLevel.Medium
                });
                await _skillRepository.AddAsync(new Skill()
                {
                    Name= SkillLevel.Hard
                });
            }
        }
    }
}
