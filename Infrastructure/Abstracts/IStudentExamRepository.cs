﻿using Data.Entities.Models;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IStudentExamRepository : IGenericeRepositoryAsync<StudentExam>
    {
        public Task<StudentExam> GetStudentExamAscync(Guid userId, Guid id);
    }
}
