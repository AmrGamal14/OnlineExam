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
    public class ExamQuestionRepository : GenericRepositoryAsync<ExamQuestion>, IExamQuestionRepository
    {
        #region Fields
        private readonly DbSet<ExamQuestion> _examQuestions;
        #endregion
        #region Constructors
        public ExamQuestionRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _examQuestions=dBContext.Set<ExamQuestion>();

        }
        public virtual async Task<List<ExamQuestion>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<ExamQuestion, object>>[] includeProperties)
        {
            try
            {
                var query = _examQuestions.AsQueryable();
                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);

                var result = await query.Where(x => Ids.Contains(x.StudentExamId)).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return new List<ExamQuestion>();
            }
        }
        #endregion
    }
}
