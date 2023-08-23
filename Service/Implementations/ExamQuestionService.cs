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
        private readonly IUnitOfWork _unitOfWork;

        public ExamQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddListAsync(List<ExamQuestion> examQuestion)
        {
            var result = await _unitOfWork.examQuestion.AddListAsync(examQuestion);
            return "Success";
        }
    
    
    }
}
