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
    public class GetStudentQuestionsHandler : ResponseHandler  , IRequestHandler<GetStudentQuestionHistory, Response<List<GetStudentQuestionHistoryResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetStudentQuestionsHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetStudentQuestionHistoryResponse>>> Handle(GetStudentQuestionHistory request, CancellationToken cancellationToken)
        {
            var StudentExamQuestions = await _unitOfWork.studentExam.GetStudentQuestionsByExamIdAscync(request.ExamId,Guid.Parse(_auditService.UserId),request.ExamDate);
            var StudentExamQuestionsMapper = _mapper.Map<List<GetStudentQuestionHistoryResponse>>(StudentExamQuestions);
            return success(StudentExamQuestionsMapper);
        }
    }
}
