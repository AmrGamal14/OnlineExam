using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IStudentResultService
    {
        public Task<string> AddAsync(StudentExamResult studentResult);
        public Task<string> AddListAsync(List<StudentExamResult> studentExamResults);
    }
}
