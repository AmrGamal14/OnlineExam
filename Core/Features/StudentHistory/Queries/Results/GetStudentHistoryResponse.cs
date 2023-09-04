using Application.Features.Questions.Queries.Result;
using Data.DTO;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Queries.Results
{
    public class GetStudentHistoryResponse
    {
        public Guid  ExmaId { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
  
    }
   

}
