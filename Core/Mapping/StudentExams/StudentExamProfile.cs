using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.StudentExams
{
    public partial class StudentExamProfile : Profile
    {
        public StudentExamProfile()
        {
            AddStudentExam();
        }
    }
}
