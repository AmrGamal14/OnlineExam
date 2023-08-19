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
    public class StudentExamConfiguration : GenericConfiguration<StudentExam, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<StudentExam> builder)
        {
            builder.HasOne(sl => sl.Exam)
                .WithMany(e => e.studentExams)
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.User)
                .WithMany(s => s.StudentExams)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    
    }
}
