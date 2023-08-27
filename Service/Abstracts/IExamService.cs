using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IExamService
    {
        public Task<List<Exam>> GetExamsListAsync(string userId,Guid id);
        public Task<Exam> GetByIdasync(Guid id);
        public Task<Exam> AddAsync(Exam exam);
        public Task<string> EditAsync(Exam exam);
        public Task<string> DeleteAsync(Exam exam);
      
    }
}
