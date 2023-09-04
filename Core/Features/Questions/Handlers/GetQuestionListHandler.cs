using Application.Bases;
using Application.Features.Questions.Queries.Models;
using Application.Features.Questions.Queries.Result;
using AutoMapper;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Handlers
{
    public class GetQuestionListHandler : ResponseHandler, IRequestHandler<GetQuestionListQuery, Response<List<GetQuestionListResponse>>>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetQuestionListHandler(IUnitOfWork unitOfWork,IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetQuestionListResponse>>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {

            var subjectlevel = await _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(request.LevelId);
            var QuestionList = await _unitOfWork.question.GetQuestionListAscync(_auditService.UserId, subjectlevel.Id);
            var QuestionListMapper = _mapper.Map<List<GetQuestionListResponse>>(QuestionList);
            return success(QuestionListMapper);
        }
    }
}
