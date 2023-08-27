using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Repositories;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Exam> AddAsync(Exam exam)
        {
            var Exam =await _unitOfWork.exam.AddAsync(exam);
            return Exam;
        }

        public async Task<string> DeleteAsync(Exam exam)
        {
            await _unitOfWork.exam.DeleteAsync(exam);
            return "Success"; 
        }

        public async Task<string> EditAsync(Exam exam)
        {
            await _unitOfWork.exam.UpdateAsync(exam);
            return "Success" ;
        }


        public async Task<Exam> GetByIdasync(Guid id)
        {
            var exam = _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==id).FirstOrDefault();
            return exam;

        }

        public Task<List<Exam>> GetExamsListAsync(string userId , Guid id )
        {
            var exam = _unitOfWork.exam.GetExamsListAsync(userId,id);
            return exam;
        }
    }
}
