using Application.Bases;
using Application.Extensions;
using Application.Features.Exams.Commands.Models;
using AutoMapper;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Handlers
{
    public class AddExamHandler : ResponseHandler, IRequestHandler<AddExamCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditService _auditService;
        public AddExamHandler(IMapper mapper, IAuditService auditService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {

            _mapper = mapper;
            _auditService = auditService;
            _unitOfWork= unitOfWork;
            _httpContextAccessor=httpContextAccessor;
        }
        public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
        {

            var subjectlevel = await _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(request.LevelId);
            var questionlist = await _unitOfWork.question.GetQuestionListAscync(_auditService.UserId, subjectlevel.Id);
            int countt = questionlist.Count();
            if (request.QuestionCount > countt)
                return BadRequest<string>("Question Count more then your question");
            if (subjectlevel == null)
                return NotFound<string>("NotFouund");
            var ExamMapper = _mapper.Map<Exam>(request);
            ExamMapper.SubjectLevelId=subjectlevel.Id;
            ExamMapper.AddEntityAudit();
            var result = await _unitOfWork.exam.AddAsync(ExamMapper);
            var ExamUrl = GenerateUrl(_httpContextAccessor, result.Id);
            ExamMapper.url=ExamUrl;
            await _unitOfWork.exam.UpdateAsync(ExamMapper);
            return success($"{ExamUrl}");
        }
       public static Uri GenerateUrl(IHttpContextAccessor accessor, Guid ExamId)
       {
          if (ExamId.ToString() != null)
          {
                   //Uri uri = new Uri($"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}/ExamQuestion?ExamId={ExamId}");
                    Uri uri = new Uri($"http://localhost:4200/student/startExam/{ExamId}");
                    return uri;
          }
               return null;
       }

        
    }
}
