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
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subject> _subjects;
        #endregion
        #region Constructors
        public SubjectRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _subjects=dBContext.Set<Subject>();
        }
        #endregion
        public async Task<List<Subject>> GetSubjectListAscync(string userId)
        {

            return await _subjects.Where(cb => cb.CreatedBy == userId).ToListAsync();
        }
    }
}
