using AutoMapper;
using Core.Bases;
using Core.Features.Questions.Queries.Result;
using Core.Features.StudentHistory.Queries.Models;
using Core.Features.StudentHistory.Queries.Results;
using Core.Features.Subjects.Queries.Models;
using Core.Features.Subjects.Queries.Result;
using Core.Resources;
using Data.Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.StudentHistory.Queries.Handlers
{
    public class GetSudentHistoryHandler : ResponseHandler, IRequestHandler<GetStudentHistory, Response<List<GetStudentHistoryResponse>>>
                                                          , IRequestHandler<GetExamHistory, Response<List<GetExamHistoryResponse>>>
                                                       
    {
        #region Fields
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuditService _auditService;
        #endregion
        #region Constructors
        public GetSudentHistoryHandler(IUnitOfWorkService unitOfWorkService,
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
        public async Task<Response<List<GetStudentHistoryResponse>>> Handle(GetStudentHistory request, CancellationToken cancellationToken)
        {
            var StudentExam = await _unitOfWorkService.studentExamSrevice.GetStudentExambyUserId(Guid.Parse(_auditService.UserId));
            var StudentExamMapper = _mapper.Map<List<GetStudentHistoryResponse>>(StudentExam);
            return success(StudentExamMapper);
        }

        public async Task<Response<List<GetExamHistoryResponse>>> Handle(GetExamHistory request, CancellationToken cancellationToken)
        {
            var StudentExam = await _unitOfWorkService.studentExamSrevice.GetStudentExamByExamIdAscync(request.ExamId);
            var StudentExamMapper = _mapper.Map<List<GetExamHistoryResponse>>(StudentExam);
            return success(StudentExamMapper);
        }

       
    }
}
