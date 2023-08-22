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
    public class SubjectLevelRepository : GenericRepositoryAsync<SubjectLevel>, ISubjectLevelRepository
    {
        #region Fields
        private readonly DbSet<SubjectLevel> _subjectsLevel;
        #endregion
        #region Constructors
        public SubjectLevelRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _subjectsLevel=dBContext.Set<SubjectLevel>();
        }

        public async Task<SubjectLevel> GetSubjectLevelByLevelIdAscync(Guid id)
        {
            var subjectLevel = _subjectsLevel.FirstOrDefault(e => e.LevelId == id);
            return subjectLevel;
        }

        #endregion

    }
}
