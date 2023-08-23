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
        private readonly IUnitOfWork _unitOfWork;     

        public LevelService( IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Level> AddAsync(Level level)
        {
            var result = await _unitOfWork.level.AddAsync(level);
            return result;
        }

        public async Task<string> DeleteAsync(Level level)
        {
            await _unitOfWork.level.DeleteAsync(level);
            return "Success";

        }

        public async Task<string> EditAsync(Level level)
        {
            await _unitOfWork.level.UpdateAsync(level);
            return "Success";
        }

        public async Task<Level> GetLevelByIdasync(Guid id)
        {
            var level = _unitOfWork.level.GetTableNoTracking().Where(x => x.Id==id).FirstOrDefault();
            return level ;
           
        }

        public async Task <List<Level>> GetLevelListBySubjectId(Guid id)
        {
            var Level =await _unitOfWork.level.GetLevelListBySubjectId(id);
            return Level;

        } 
        public async Task <Level> GetLevelBySubjectId(Guid id,string name)
        {
            var Level =await _unitOfWork.level.GetLevelBySubjectId(id,name);
            return Level;

        }

        public async Task<List<Level>> GetLevelsListAsync()
        {
            return await _unitOfWork.level.GetLevelListAscync();
        }
    }
}
