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
        public readonly IStudentExamRepository _studentExamRepository;

        public StudentExamSrevice(IStudentExamRepository studentExamRepository)
        {
            _studentExamRepository = studentExamRepository;
        }
        public async Task<StudentExam> AddAsync(StudentExam studentExam)
        {
           var result= await _studentExamRepository.AddAsync(studentExam);
            return result ;
        }
    }
}
