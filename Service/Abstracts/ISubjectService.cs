using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<List<Subject>> GetSubjectsListAsync(string userId);
        public Task<Subject> GetSubjectByIdasync(Guid id);
        public Task<Subject> GetSubjectByNameasync(string name,string id);
        public Task<string> AddAsync(Subject subject);
        public Task<string> EditAsync(Subject subject);
        public Task<string> DeleteAsync(Subject subject);

    }
}
