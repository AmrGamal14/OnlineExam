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
    public class GetQuestionAndAnswerByIdHandler : ResponseHandler, IRequestHandler<GetQuestionAndAnswerById, Response<GetByIdResponse>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetQuestionAndAnswerByIdHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<GetByIdResponse>> Handle(GetQuestionAndAnswerById request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.question.GetQuestionAndAnswerById(request.Id);
            var questionmapper = _mapper.Map<GetByIdResponse>(question);
            return success(questionmapper);

        }
    }
}
