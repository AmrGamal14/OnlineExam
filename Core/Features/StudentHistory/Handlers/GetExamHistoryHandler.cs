using Application.Bases;
using Application.Features.StudentHistory.Queries.Models;
using Application.Features.StudentHistory.Queries.Results;
using AutoMapper;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Handlers
{
    public class GetExamHistoryHandler : ResponseHandler, IRequestHandler<GetExamHistory, Response<List<GetExamHistoryResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetExamHistoryHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetExamHistoryResponse>>> Handle(GetExamHistory request, CancellationToken cancellationToken)
        {
            var StudentExam = await _unitOfWork.studentExam.GetStudentExamByExamIdAscync(request.ExamId);
            var StudentExamMapper = _mapper.Map<List<GetExamHistoryResponse>>(StudentExam);
            return success(StudentExamMapper);
        }
    }
}
