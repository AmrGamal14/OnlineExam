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

        public async Task <List<StudentExam>> GetStudentExamByExamIdAscync(Guid id)
        {
            var StudentExam = await _studentExams.Where(cb =>cb.ExamId==id).Include(u=>u.User).ToListAsync();
               
            return StudentExam; 
        }

        //public async Task<List<StudentExam>> GetStudentExambyUserId(Guid userId)
        //{
        //    var StudentExam =  _studentExams.Where(cb => cb.UserId == userId).Include(e=>e.Exam)./*Include(s=>s.StudentExamResults).ThenInclude(e=>e.Answer).ThenInclude(q=>q.Question)*/AsQueryable();
        //    return StudentExam;
        //}
        public IQueryable<StudentExam> GetStudentExambyUserId(Guid userId)
        {
            var StudentExam = _studentExams.Where(cb => cb.UserId == userId).Include(e => e.Exam).AsQueryable();
            return StudentExam;
        }

        public async Task<List<StudentExam>> GetStudentQuestionsByExamIdAscync(Guid id, Guid UserId, DateTime ExamDate)
        {
            var StudentExam = await _studentExams.Where(cb => cb.ExamId==id&&cb.UserId==UserId&&cb.ExamDate==ExamDate).Include(s=>s.StudentExamResults).ThenInclude(a=>a.Answer).ThenInclude(q => q.Question).ToListAsync();

            return StudentExam;
        }
        #endregion
    }
}
