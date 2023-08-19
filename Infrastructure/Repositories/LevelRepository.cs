using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LevelRepository : GenericRepositoryAsync<Level>, ILevelRepository
    {
        #region Fields
        private readonly DbSet<Level> _level;
        private readonly DbSet<SubjectLevel> _subjectLevel;
        #endregion
        #region Constructors
        public LevelRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _level=dBContext.Set<Level>();
            _subjectLevel=dBContext.Set<SubjectLevel>();
        }
        #endregion
        public async Task<List<Level>> GetLevelListAscync()
        {
            return await _level.ToListAsync();
        }
        public async Task<List<Level>> GetLevelListBySubjectId(Guid id)
        {

            var Levels = await _subjectLevel.Include(l => l.Level).Where(x => x.SubjectId == id)
                .Select(l => l.Level).ToListAsync();
            return Levels;
        }
    }
}
