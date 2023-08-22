using Data.Entities.Models;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface ILevelRepository : IGenericeRepositoryAsync<Level>
    {
        public Task<List<Level>> GetLevelListAscync();
        public Task<List<Level>> GetLevelListBySubjectId(Guid id);
        public Task<Level> GetLevelBySubjectId(Guid id, string name);
    }
}
