using Data.Audit;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InfrastructureBases
{
    public interface IGenericeRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task<List<T>> AddListAsync(List<T> entity);
        Task AddRangeAsync(ICollection<T> entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAll();

    }
}
