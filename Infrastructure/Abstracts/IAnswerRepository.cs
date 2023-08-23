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
    public interface IAnswerRepository : IGenericeRepositoryAsync<Answers>
    {
        public Task<List<Answers>> GetAnswerListByQuestionId(Guid id);
        public Task<List<Answers>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<Answers, object>>[] includeProperties);
    }
}
