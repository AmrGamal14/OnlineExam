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
    public class ExamQuestionRepository : GenericRepositoryAsync<ExamQuestion>, IExamQuestionRepository
    {
        #region Fields
        private readonly DbSet<ExamQuestion> _examQuestions;
        #endregion
        #region Constructors
        public ExamQuestionRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _examQuestions=dBContext.Set<ExamQuestion>();

        }
        #endregion
    }
}
