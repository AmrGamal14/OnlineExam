using Core.Features.Levels.Queries.Results;
using Core.Features.Subjects.Queries.Result;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Levels
{
    public partial class LevelProfile
    {
        public void GetLevelListQuery()
        {
            CreateMap<Level, GetLevelListResponse>();
        }
    }
}
