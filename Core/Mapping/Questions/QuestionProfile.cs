using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Questions
{
    public partial class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            AddQuestiotCommand();
            EditQuestion();
            GetQuestionListQuery();
            GetQuestionRandom();
        }
    }
}
