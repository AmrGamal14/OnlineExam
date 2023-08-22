using AutoMapper;
using Core.Bases;
using Core.Extensions;
using Core.Features.Exams.Commands.Models;
using Core.Features.Levels.Commands.Models;
using Data.Entities.Models;
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
        public ExamCommandHandler (IMapper mapper,IUnitOfWorkService unitOfWorkService, IExamService examService, IHttpContextAccessor httpContextAccessor)
        {

            _mapper = mapper;
            _unitOfWorkService= unitOfWorkService;  
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
        {
            var subjectlevel=await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);

            if (subjectlevel == null)
                return NotFound<string>("NotFouund");
            var ExamMapper = _mapper.Map<Exam>(request);
            ExamMapper.SubjectLevelId=subjectlevel.Id;
            ExamMapper.AddEntityAudit();
            var result = await _unitOfWorkService.examService.AddAsync(ExamMapper);
            var ExamUrl = GenerateUrl(_httpContextAccessor, result.Id);

            return success($"{ExamUrl}");
        }
        public static Uri GenerateUrl(IHttpContextAccessor accessor,  Guid ExamId)
        {
            if (ExamId.ToString() != null)
            {
                Uri uri = new Uri($"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}/ExamQuestion?ExamId={ExamId}");
                return uri;
            }
            return null;
        }

        public async Task<Response<string>> Handle(EditExamCommand request, CancellationToken cancellationToken)
        {
            var OldExam = await _unitOfWorkService.examService.GetByIdasync(request.Id);
            if (OldExam == null)
                return NotFound<string>("NotFouund");
            var Levelmapper = _mapper.Map<Exam>(request);
            Levelmapper.SubjectLevelId=OldExam.SubjectLevelId;
            var result = await _unitOfWorkService.examService.EditAsync(Levelmapper);
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
