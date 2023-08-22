﻿using AutoMapper;
using Core.Bases;
using Core.Features.Levels.Queries.Models;
using Core.Features.Levels.Queries.Results;
using Core.Features.Questions.Commands.Models;
using Core.Features.Questions.Queries.Models;
using Core.Features.Questions.Queries.Result;
using Core.Resources;
using Data.Entities.Models;
using Data.DTO;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Queries.Handlers
{
    public class QuestionQueryHandler : ResponseHandler, IRequestHandler<GetQuestionListQuery, Response<List<GetQuestionListResponse>>>
                                                          , IRequestHandler<GetQuestionRandom, Response<List<GetQuestionRandomResponse>>>
    {
        #region Fields
        //private readonly IQuestionService _questionService;
        //private readonly IAnswerService _answerService;
        //private readonly IExamService _examService;
        //private static ISubjectLevelService _subjectLevelService;
        //private static IStudentExamSrevice _studentExamSrevice;
        //private static IExamQuestionService _examQuestionService;
        private static IUnitOfWorkService _unitOfWorkService;
        private readonly IAuditService _auditService;
        private static IServiceScopeFactory _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public QuestionQueryHandler(IUnitOfWorkService unitOfWorkService,
                                    IMapper mapper,
                                  IServiceScopeFactory serviceScope,
                                    IAuditService auditService,
                                     IStringLocalizer<SharedResources> stringLocalizer)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper=mapper;
            _serviceProvider = serviceScope;
            _auditService=auditService;
            _stringLocalizer=stringLocalizer;
        }

        public async Task<Response<List<GetQuestionListResponse>>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {

            var subjectlevel = await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);
            var QuestionList = await _unitOfWorkService.questionService.GetQuestionListAsync(_auditService.UserId,subjectlevel.Id);
             var QuestionListMapper = _mapper.Map<List<GetQuestionListResponse>>(QuestionList);
            return success(QuestionListMapper);
        }

        public async Task<Response<List<GetQuestionRandomResponse>>> Handle(GetQuestionRandom request, CancellationToken cancellationToken)
        {
            var exam = await _unitOfWorkService.examService.GetByIdasync(request.ExamId);
            var QuestionList = await _unitOfWorkService.questionService.GetQuestionRandomAsync(request.ExamId);
            var QuestionListMapper = _mapper.Map<List<GetQuestionRandomResponse>>(QuestionList);
            QuestionListMapper.ForEach(a => a.TitleExam=exam.Title);
            QuestionListMapper.ForEach(a => a.Duration=exam.Duration);
            using var scope = _serviceProvider.CreateScope();
            var auditService = scope.ServiceProvider.GetService<IAuditService>();
            StudentExamForm FormattingSL = new();
            FormattingSL.ExamId=request.ExamId;
            FormattingSL.ExamDate=DateTime.UtcNow;
            FormattingSL.UserId=  Guid.Parse(auditService.UserId);
            var StudentExamMapper = _mapper.Map<StudentExam>(FormattingSL);
            var Result = await _unitOfWorkService.studentExamSrevice.AddAsync(StudentExamMapper);
            var ExamQuestionMap = _mapper.Map<List<ExamQuestion>>(QuestionList);
            ExamQuestionMap.ForEach(qId => qId.StudentExamId = Result.Id);
            var result = await _unitOfWorkService.examQuestionService.AddListAsync(ExamQuestionMap);


            return success(QuestionListMapper);
        }
        #endregion
    }
}
