using Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class LevelConfiguration : GenericConfiguration<Level, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<Level> builder)
        {
            
        }
    }
}
