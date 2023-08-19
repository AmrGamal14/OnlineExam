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
    public class StudentExamResultConfiguration : GenericConfiguration<StudentExamResult, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<StudentExamResult> builder)
        {
            builder.HasOne(sl => sl.StudentExam)
                .WithMany(e => e.StudentExamResults)
                .HasForeignKey(s => s.StudentExamId)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.HasOne(sl => sl.ExamQuestion)
               .WithMany(e => e.StudentExamResults)
               .HasForeignKey(s => s.ExamQuestionId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(sl => sl.Answer)
               .WithMany(e => e.StudentExamResults)
               .HasForeignKey(s => s.AnswerId)
               .OnDelete(DeleteBehavior.Cascade);

           



        }
    
    }
}
