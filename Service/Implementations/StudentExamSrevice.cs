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
            _unitOfWork.Complete();
            return result ;
        }
    }
}
