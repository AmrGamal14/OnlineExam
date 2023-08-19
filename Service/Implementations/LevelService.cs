using Data.Audit;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Repositories;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class LevelService : ILevelService 
    {
        private readonly ILevelRepository _levelRepository;   

        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository=levelRepository;
        }

        public async Task<Level> AddAsync(Level level)
        {
            var result = await _levelRepository.AddAsync(level);
            return result;
        }

        public async Task<string> DeleteAsync(Level level)
        {
            await _levelRepository.DeleteAsync(level);
            return "Success";

        }

        public async Task<string> EditAsync(Level level)
        {
            await _levelRepository.UpdateAsync(level);
            return "Success";
        }

        public async Task<Level> GetLevelByIdasync(Guid id)
        {
            var level =  _levelRepository.GetTableNoTracking().Where(x => x.Id==id).FirstOrDefault();
            return level ;
           
        }

        public async Task <List<Level>> GetLevelListBySubjectId(Guid id)
        {
            var Level =await _levelRepository.GetLevelListBySubjectId(id);
            return Level;

        }

        public async Task<List<Level>> GetLevelsListAsync()
        {
            return await _levelRepository.GetLevelListAscync();
        }
    }
}
