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
    public class ExamQuestionsConfiguration : GenericConfiguration<ExamQuestion, Guid>
    {
        public override void CustomConfig(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasOne(sl => sl.StudentExam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(s => s.StudentExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sl => sl.Question)
               .WithMany(e => e.ExamQuestions)
               .HasForeignKey(s => s.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    
    
    }
}
