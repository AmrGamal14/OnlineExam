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
    public class StudentResultRepository : GenericRepositoryAsync<StudentExamResult>, IStudentResultRepository
    {
        #region Fields
        private readonly DbSet<StudentExamResult> _studentResults;
        #endregion
        #region Constructors
        public StudentResultRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _studentResults=dBContext.Set<StudentExamResult>();

        }
        #endregion
    }
}
