using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IExamQuestionService
    {
        public Task<string> AddListAsync(List<ExamQuestion> examQuestion);
        public Task<List<ExamQuestion>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<ExamQuestion, object>>[] includeProperties);
       
       
    }
}
