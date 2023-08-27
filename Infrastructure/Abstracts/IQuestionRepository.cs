using Data.Entities.Models;
using Data.DTO;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infrastructure.Abstracts
{
    public interface IQuestionRepository  :IGenericeRepositoryAsync<Question>
    {
        public Task<List<Question>> GetQuestionListAscync(string userId, Guid id);
        public Task<List<Question>> GetRandomQuestions( Guid id);
        public Task<Question> GetQuestionAndAnswerById( Guid id);
        public Task<List<Question>> GetByMultipleIdsAsync(List<Guid> Ids, List<Guid> id, params Expression<Func<Question, object>>[] includeProperties);
    }
}
