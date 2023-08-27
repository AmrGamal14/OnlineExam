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
    public class StudentResultRepository : GenericRepositoryAsync<StudentExamResult>, IStudentResultRepository
    {
        #region Fields
        private readonly DbSet<StudentExamResult> _studentResults;
        #endregion
        #region Constructors
        public StudentResultRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _studentResults=dBContext.Set<StudentExamResult>();

        }

        public async Task<List<StudentExamResult>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<StudentExamResult, object>>[] includeProperties)
        {
            try
            {
                var query = _studentResults.AsQueryable();
                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);

                var result = await query.Where(x => Ids.Contains(x.Id)).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return new List<StudentExamResult>();
            }
        }
        #endregion
    }
}
