using AutoMapper;
using Core.Features.Questions.Queries.Result;
using Core.Features.Subjects.Queries.Result;
using Data.Entities.Models;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Questions
{
    public partial class QuestionProfile
    {
        
        public void GetQuestionListQuery()
        {

            //CreateMap<Answers, AnswersList>();

            //CreateMap<Question, GetQuestionListResponse>()
            //.ForMember(dest => dest.AnswersList, opt => opt.MapFrom(src => src.Answers));
        }
    }
}
