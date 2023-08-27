using Data.Entities.Models;
using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<List<ExamQuestion>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<ExamQuestion, object>>[] includeProperties)
        {
            var Examquestion = _unitOfWork.examQuestion.GetByMultipleIdsAsync(Ids);
            return Examquestion;
        }
    }
}
