﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Skills
{
    public partial class SkillProfile : Profile
    {
        public SkillProfile()
        {
            AddSkill();
        }
    }
}
