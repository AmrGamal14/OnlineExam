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
        public Task<List<StudentExam>> GetStudentExamByExamIdAscync( Guid id);
        public Task<List<StudentExam>> GetStudentExambyUserId(Guid userId);

    }
}
