using Data.Entities.Models;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.StudentExams
{
    public partial class StudentExamProfile
    {
        public void AddStudentExam()
        {
            CreateMap<StudentExamForm, StudentExam>();
        }
    }
}
