using AutoMapper;
using Core.Features.Answer.Command.Models;
using Core.Features.Answer.Queries.Result;
using Core.Features.Exams.Commands.Models;
using Core.Features.Levels.Commands.Models;
using Core.Features.Levels.Queries.Results;
using Core.Features.Questions.Commands.Models;
using Core.Features.Questions.Queries.Result;
using Core.Features.Subjects.Commands.Models;
using Core.Features.Subjects.Queries.Result;
using Core.Features.UserCQRS.Command.Models;
using Core.Features.UserCQRS.Query.Result;
using Data.DTO;
using Data.Entities.Identity;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswersList = Core.Features.Questions.Queries.Result.AnswersList;

namespace Core.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {   //UserMapper
            CreateMap<User, GetUserListResult>();
            CreateMap<AddUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            //SubjectMapper
            CreateMap<AddSubjectCommand, Subject>();
            CreateMap<EditSubjectCommand, Subject>();
            CreateMap<Subject, GetSubjectListResponse>();

            //LevelMapper
            CreateMap<AddLevelCommand, Level>();
            CreateMap<EditLevelCommand, Level>();
            CreateMap<Level, GetLevelListResponse>();

            //SubjectLevelMapper
            CreateMap<SubjectLevelList, SubjectLevel>();

            //QuestionMapper
            CreateMap<QuestionList, Question>();
            CreateMap<EditQuestionCommand, Question>();
            CreateMap<Answers, AnswersList>();
            CreateMap<Question, GetQuestionListResponse>()
            .ForMember(dest => dest.AnswersList, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Answers, answerlist>();
            CreateMap<Question, GetQuestionRandomResponse>()
                .ForMember(dest => dest.answerlist, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Exam, GetQuestionRandomResponse>();

            //SkillMApper
            CreateMap<AddQuestionAndAnswerCommand, Skill>();

            //AnswerMapper
            CreateMap<AnswersLists, Answers>().ReverseMap();
            CreateMap<AddAnswerCommand, Answers>().ReverseMap();
            CreateMap<EditAnswerCommand, Answers>().ReverseMap();
            CreateMap<Answers, GetAnswerListResponse>().ReverseMap();

            //ExamMapper
            CreateMap<AddExamCommand, Exam>();
            CreateMap<EditExamCommand, Exam>();

            //StudentExamMapper
            CreateMap<StudentExamForm, StudentExam>();

            //ExamQuestionMapper
            CreateMap<Question, ExamQuestion>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Id));
            CreateMap<StudentExam, ExamQuestion>();

        }
       
    }
}
