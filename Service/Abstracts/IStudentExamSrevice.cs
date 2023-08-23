using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IStudentExamSrevice
    {
        public Task<StudentExam> AddAsync(StudentExam studentExam);
        public Task<string> UpdateAsync(StudentExam studentExam);
        public Task<StudentExam> GetStudentExamAscync(Guid userId, Guid id);

    }
}
