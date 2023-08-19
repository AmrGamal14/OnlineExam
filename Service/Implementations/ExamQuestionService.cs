using Data.Entities.Models;
using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ExamQuestionService : IExamQuestionService
    {
        public readonly IExamQuestionRepository _examQuestionRepository;

        public ExamQuestionService(IExamQuestionRepository examQuestionRepository)
        {
            _examQuestionRepository = examQuestionRepository;
        }
        public async Task<string> AddListAsync(List<ExamQuestion> examQuestion)
        {
            var result = await _examQuestionRepository.AddListAsync(examQuestion);
            return "Success";
        }
    
    
    }
}
