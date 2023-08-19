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
    public class ExamRepository : GenericRepositoryAsync<Exam>, IExamRepository
    {
        #region Fields
        private readonly DbSet<Exam> _exams;
        #endregion
      
        public ExamRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _exams=dBContext.Set<Exam>();

        }

       
    }
}
