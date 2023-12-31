﻿using Data.Entities.Models;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IExamRepository : IGenericeRepositoryAsync<Exam>
    {
        public Task<List<Exam>> GetExamsListAsync(string userId,Guid id);
       
    }
}
