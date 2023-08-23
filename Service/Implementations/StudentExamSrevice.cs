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
    public class StudentExamSrevice : IStudentExamSrevice
    {
        public readonly IUnitOfWork _unitOfWork;

        public StudentExamSrevice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentExam> AddAsync(StudentExam studentExam)
        {
           var result= await _unitOfWork.studentExam.AddAsync(studentExam);
            return result ;
        }

        public async Task<StudentExam> GetStudentExamAscync(Guid userId, Guid id)
        {
            var result = await _unitOfWork.studentExam.GetStudentExamAscync(userId,id);
            return result;
        }

        public async Task<string> UpdateAsync(StudentExam studentExam)
        {
            await _unitOfWork.studentExam.UpdateAsync(studentExam);
            return "Success";
        }
    }
}
