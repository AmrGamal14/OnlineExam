﻿using Data.Entities.Models;
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
    public class StudentExamRepository : GenericRepositoryAsync<StudentExam>, IStudentExamRepository
    {
        #region Fields
        private readonly DbSet<StudentExam> _studentExams;
        #endregion
        #region Constructors
        public StudentExamRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _studentExams=dBContext.Set<StudentExam>();

        }
        #endregion
    }
}
