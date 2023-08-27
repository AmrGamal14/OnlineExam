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
    public interface IStudentResultRepository : IGenericeRepositoryAsync<StudentExamResult>
    {
        public Task<List<StudentExamResult>> GetByMultipleIdsAsync(List<Guid> Ids, params Expression<Func<StudentExamResult, object>>[] includeProperties);
    }
}
