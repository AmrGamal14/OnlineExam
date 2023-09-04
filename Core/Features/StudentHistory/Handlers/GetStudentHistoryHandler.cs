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
    public class GetStudentHistoryHandler : ResponseHandler, IRequestHandler<GetStudentHistory, Response<List<GetStudentHistoryResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetStudentHistoryHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetStudentHistoryResponse>>> Handle(GetStudentHistory request, CancellationToken cancellationToken)
        {
            var StudentExam = await _unitOfWork.studentExam.GetStudentExambyUserId(Guid.Parse(_auditService.UserId));
            var StudentExamMapper = _mapper.Map<List<GetStudentHistoryResponse>>(StudentExam);

            return success(StudentExamMapper);
        }
    }
}
