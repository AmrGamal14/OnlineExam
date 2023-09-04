using Data.Entities.Models;
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
        public Task<List<StudentExam>> GetStudentExamByExamIdAscync( Guid id);
        public Task<List<StudentExam>> GetStudentQuestionsByExamIdAscync( Guid id , Guid UserId , DateTime ExamDate);
        public Task<List<StudentExam>> GetStudentExambyUserId(Guid userId);
    }
}
