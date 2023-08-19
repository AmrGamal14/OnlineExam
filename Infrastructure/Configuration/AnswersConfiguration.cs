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
    public class AnswersConfiguration : GenericConfiguration<Answers, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<Answers> builder)
        {
            builder.HasOne(sl => sl.Question)
                .WithMany(e => e.Answers)
                .HasForeignKey(s => s.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    
    }
}
