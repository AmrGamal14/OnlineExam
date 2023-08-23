using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AnswerRepository : GenericRepositoryAsync<Answers>, IAnswerRepository
    {
        #region Fields
        private readonly DbSet<Answers> _answers;
        #endregion
        #region Constructors
        public AnswerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _answers=dBContext.Set<Answers>();
          
        }

        public async Task<List<Answers>> GetAnswerListByQuestionId(Guid id)
        {
            var Answer = await _answers.Where(x => x.QuestionId == id).ToListAsync();
            return Answer;
        }
        public virtual async Task<List<Answers>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<Answers, object>>[] includeProperties)
        {
            try
            {
                var query = _answers.AsQueryable();
                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);

                var result = await query.Where(x => Ids.Contains(x.Id)).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return new List<Answers>();
            }
        }
        #endregion

    }
}
