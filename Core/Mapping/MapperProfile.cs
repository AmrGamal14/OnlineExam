using AutoMapper;
using Application.Features.Answer.Command.Models;
using Application.Features.Answer.Queries.Result;
using Application.Features.Exams.Commands.Models;
using Application.Features.Exams.Queries.Result;
using Application.Features.Levels.Commands.Models;
using Application.Features.Levels.Queries.Results;
using Application.Features.Questions.Commands.Models;
using Application.Features.Questions.Queries.Result;
using Application.Features.StudentHistory.Queries.Results;
using Application.Features.Subjects.Commands.Models;
using Application.Features.Subjects.Queries.Result;
using Application.Features.UserCQRS.Command.Models;
using Application.Features.UserCQRS.Query.Result;
using Data.DTO;
using Data.Entities.Identity;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswersList = Application.Features.Questions.Queries.Result.AnswersList;

namespace Application.Mapping
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
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForPath(dest => dest.answerlist, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Exam, GetQuestionRandomResponse>();
            CreateMap<Answers, answerslist>();
            CreateMap<Skill, GetByIdResponse>();
            CreateMap<Question, GetByIdResponse>()
                .ForMember(dest=>dest.Answer, opt=>opt.MapFrom(src=>src.Answers))
                .ForMember(dest=>dest.SkillLevel, opt=>opt.MapFrom(src=>src.Skill.Name));



            //SkillMApper
            CreateMap<AddQuestionAndAnswerCommand, Skill>();

            //AnswerMapper
            CreateMap<AnswersLists, Answers>().ReverseMap();
            CreateMap<answer, Answers>().ReverseMap();
            CreateMap<AddAnswerCommand, Answers>().ReverseMap();
            CreateMap<EditAnswerCommand, Answers>().ReverseMap();
            CreateMap<Answers, GetAnswerListResponse>().ReverseMap();

            //ExamMapper
            CreateMap<AddExamCommand, Exam>();
            CreateMap<EditExamCommand, Exam>();
            CreateMap<Exam, GetExamListResponse>();
            CreateMap<Exam, GetExamResponse>();
            //StudentExamMapper
            CreateMap<StudentExamForm, StudentExam>();
            CreateMap<ScoreExam, StudentExam>();
            CreateMap<StudentExam, GetStudentHistoryResponse>()
                .ForMember(dest => dest.QuestionCount, opt => opt.MapFrom(src => src.Exam.QuestionCount))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Exam.Title))
                .ForMember(dest => dest.ExmaId, opt => opt.MapFrom(src => src.Exam.Id))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Exam.Duration));
               
         


            CreateMap<Exam, GetStudentHistoryResponse>();
            CreateMap<StudentExam, GetExamHistoryResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.ExamDate, opt => opt.MapFrom(src => src.ExamDate))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));
            //       .ForMember(dest => dest.historyLists, opt => opt.MapFrom(src => src.StudentExamResults));
            //CreateMap<StudentExamResult, HistoryLists>()
            //    .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Answer.Question))
            //    .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));

            CreateMap<StudentExam,GetStudentQuestionHistoryResponse>()
                 .ForMember(dest => dest.historyLists, opt => opt.MapFrom(src => src.StudentExamResults));


            CreateMap<StudentExamResult, HistoryList>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Answer.Question))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));
            CreateMap<Question, QuestionHistory>();
            CreateMap<Answers, AnswersHistory>();


            CreateMap<User, GetExamHistoryResponse>();


            //ExamQuestionMapper
            CreateMap<StudentExam, ExamQuestion>();
            CreateMap<CorrectList, ExamQuestion>()
               .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId));
            //StudentExamResultMapper
            CreateMap<AnswerList, StudentExamResult>()
                .ForMember(dest => dest.AnswerId, opt => opt.MapFrom(src => src.AnswerId))
                .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect));

            CreateMap<StudentExam,StudentExamResult>();
        }
       
    }
}
