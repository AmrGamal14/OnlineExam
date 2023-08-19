using Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class QuestionConfiguration : GenericConfiguration<Question, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(sl => sl.SubjectLevel)
                .WithMany(e => e.Questions)
                .HasForeignKey(s => s.SubjectLevelId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(sl => sl.Skill)
                .WithMany(e => e.Questions)
                .HasForeignKey(s => s.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    
    }
}
