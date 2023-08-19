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
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository=examRepository;
        }

        public async Task<Exam> AddAsync(Exam exam)
        {
            var Exam =await _examRepository.AddAsync(exam);
            return Exam;
        }

        public async Task<string> DeleteAsync(Exam exam)
        {
            await _examRepository.DeleteAsync(exam);
            return "Success"; 
        }

        public async Task<string> EditAsync(Exam exam)
        {
            await _examRepository.UpdateAsync(exam);
            return "Success" ;
        }
        public async Task<Exam> GetByIdasync(Guid id)
        {
            var exam = _examRepository.GetTableNoTracking().Where(x => x.Id==id).FirstOrDefault();
            return exam;

        }
    }
}
