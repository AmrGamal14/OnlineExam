using Data.Entities.Models;
using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class StudentResultService : IStudentResultService
    {
        public readonly IUnitOfWork _unitOfWork;

        public StudentResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddAsync(StudentExamResult studentResult)
        {
            var result = await _unitOfWork.studentResult.AddAsync(studentResult);
            return "Success";
        }
        public async Task<string> AddListAsync(List<StudentExamResult> studentExamResults)
        {
            var result = await _unitOfWork.studentResult.AddListAsync(studentExamResults);
            return "Success";
        }
    }
}
