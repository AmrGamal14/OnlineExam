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
    public class AnswerRepository : GenericRepositoryAsync<Answers>, IAnswerRepository
    {
        #region Fields
        private readonly DbSet<Answers> _answers;
        #endregion
        #region Constructors
        public AnswerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _answers=dBContext.Set<Answers>();
          
        }

        public async Task<List<Answers>> GetAnswerListByQuestionId(Guid id)
        {
            var Levels = await _answers.Where(x => x.QuestionId == id).ToListAsync();
            return Levels;
        }
        #endregion

    }
}
