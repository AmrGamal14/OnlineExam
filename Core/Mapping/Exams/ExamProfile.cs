using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Exams
{
    public partial class ExamProfile : Profile
    {
        public ExamProfile()
        {
            AddExam();
            EditExam();

        }
    }
}
