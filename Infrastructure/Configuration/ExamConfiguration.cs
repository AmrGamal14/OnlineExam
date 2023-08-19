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
    public class ExamConfiguration : GenericConfiguration<Exam, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<Exam> builder)
        {
            builder.HasOne(sl => sl.SubjectLevel)
                .WithMany(e => e.Exams)
                .HasForeignKey( s=> s.SubjectLevelId)
                .OnDelete(DeleteBehavior.Cascade);

        }
   
    }
}
