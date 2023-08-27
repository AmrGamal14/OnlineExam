using AutoMapper;
using Core.Bases;
using Core.Features.Exams.Queries.Models;
using Core.Features.Exams.Queries.Result;
using Core.Features.Subjects.Queries.Models;
using Core.Features.Subjects.Queries.Result;
using Core.Resources;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Exams.Queries.Handlers
{
    public class ExamQueryHandler : ResponseHandler, IRequestHandler<GetExamListQuery, Response<List<GetExamListResponse>>>
                                                   , IRequestHandler<GetExamByIdQuery, Response<GetExamResponse>>
    {
        #region Fields
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuditService _auditService;
        #endregion
        #region Constructors
        public ExamQueryHandler(IUnitOfWorkService unitOfWorkService,
                                    IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer,
                                     IAuditService auditService)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
            _auditService=auditService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetExamListResponse>>> Handle(GetExamListQuery request, CancellationToken cancellationToken)
        {
            var subjectlevel = await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);
            var ExamList = await _unitOfWorkService.examService.GetExamsListAsync(_auditService.UserId , subjectlevel.Id);
            var ExamListMapper = _mapper.Map<List<GetExamListResponse>>(ExamList);
            return success(ExamListMapper);
        }

        public async Task<Response<GetExamResponse>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var Exam = await _unitOfWorkService.examService.GetByIdasync(request.Id);
            var ExamMapper = _mapper.Map<GetExamResponse>(Exam);
            return success(ExamMapper);
        }
        #endregion
    }
}
