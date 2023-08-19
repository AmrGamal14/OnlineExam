using Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class SubjectLevelConfiguration : GenericConfiguration<SubjectLevel, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<SubjectLevel> builder)
        {
            //builder.Ignore(i => i.Id);

            //builder.HasKey(sl => new { sl.LevelId, sl.SubjectId });

            builder.HasOne(s => s.Subject)
                .WithMany(sl => sl.SubjectLevels)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Level)
                .WithMany(l => l.SubjectLevels)
                .HasForeignKey(l => l.LevelId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
