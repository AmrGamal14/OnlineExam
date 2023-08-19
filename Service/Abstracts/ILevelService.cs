using Data.Audit;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface ILevelService 
    {
        public Task<List<Level>> GetLevelsListAsync();
        public Task<Level> GetLevelByIdasync(Guid id);
        public Task<List<Level>> GetLevelListBySubjectId(Guid id);
        public Task<Level> AddAsync(Level level);
        public Task<string> EditAsync(Level level);
        public Task<string> DeleteAsync(Level level);
    }
}
