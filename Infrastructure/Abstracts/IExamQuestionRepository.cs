using Data.Entities.Models;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IExamQuestionRepository : IGenericeRepositoryAsync<ExamQuestion>
    {
        public Task<List<ExamQuestion>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<ExamQuestion, object>>[] includeProperties);
    }
}
