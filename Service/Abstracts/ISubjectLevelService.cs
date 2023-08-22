using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface ISubjectLevelService
    {
        public Task<string> AddAsync(SubjectLevel subjectLevel);
        public Task<SubjectLevel> GetSubjectLevelByLevelIdasync(Guid id);
    }
}
