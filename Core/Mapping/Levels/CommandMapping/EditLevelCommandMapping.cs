using Core.Features.Levels.Commands.Models;
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
        public void EditLevelCommand()
        {

            CreateMap<EditLevelCommand, Level>();
        }
    }
}
