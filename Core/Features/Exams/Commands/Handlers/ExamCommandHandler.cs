using AutoMapper;
using Core.Bases;
using Core.Extensions;
using Core.Features.Exams.Commands.Models;
using Core.Features.Levels.Commands.Models;
using Data.Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Exams.Commands.Handlers
{
    public class ExamCommandHandler : ResponseHandler, IRequestHandler<AddExamCommand, Response<string>>
                                                     , IRequestHandler<EditExamCommand, Response<string>>
                                                     , IRequestHandler<DeleteExamCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditService _auditService;
        public ExamCommandHandler (IMapper mapper,IAuditService auditService,IUnitOfWorkService unitOfWorkService, IExamService examService, IHttpContextAccessor httpContextAccessor)
        {

            _mapper = mapper;
            _auditService = auditService;
            _unitOfWorkService= unitOfWorkService;  
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
        {
            var subjectlevel=await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);
            var questionlist = await _unitOfWorkService.questionService.GetQuestionListAsync(_auditService.UserId, subjectlevel.Id);
            int countt = questionlist.Count();
            if (request.QuestionCount > countt)
                return BadRequest<string>("Question Count more then your question");
            if (subjectlevel == null)
                return NotFound<string>("NotFouund");
            var ExamMapper = _mapper.Map<Exam>(request);
            ExamMapper.SubjectLevelId=subjectlevel.Id;
            ExamMapper.AddEntityAudit();
            var result = await _unitOfWorkService.examService.AddAsync(ExamMapper);
            var ExamUrl = GenerateUrl(_httpContextAccessor, result.Id);
            ExamMapper.url=ExamUrl;
            var res = await _unitOfWorkService.examService.EditAsync(ExamMapper);
            return success($"{ExamUrl}");
        }
        public static Uri GenerateUrl(IHttpContextAccessor accessor,  Guid ExamId)
        {
            if (ExamId.ToString() != null)
            {
                //Uri uri = new Uri($"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}/ExamQuestion?ExamId={ExamId}");
                Uri uri = new Uri($"http://localhost:4200/student/startExam/{ExamId}");
                return uri;
            }
            return null;
        }

        public async Task<Response<string>> Handle(EditExamCommand request, CancellationToken cancellationToken)
        {
            var OldExam = await _unitOfWorkService.examService.GetByIdasync(request.Id);
            if (OldExam == null)
                return NotFound<string>("NotFouund");
            var Exammapper = _mapper.Map<Exam>(request);
            Exammapper.AddEntityAudit();
            Exammapper.SubjectLevelId=OldExam.SubjectLevelId;
            Exammapper.url=OldExam.url;
            var result = await _unitOfWorkService.examService.EditAsync(Exammapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _unitOfWorkService.examService.GetByIdasync(request.Id);
            if (exam==null) return NotFound<string>("Notfouund");
            var result = await _unitOfWorkService.examService.DeleteAsync(exam);
            return success("");
        }
    }
}
