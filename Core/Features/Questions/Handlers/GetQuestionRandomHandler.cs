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
    public class GetQuestionRandomHandler : ResponseHandler, IRequestHandler<GetQuestionRandom, Response<List<GetQuestionRandomResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetQuestionRandomHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetQuestionRandomResponse>>> Handle(GetQuestionRandom request, CancellationToken cancellationToken)
        {
            var exam =  _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.ExamId).FirstOrDefault();
            var QuestionList = await _unitOfWork.question.GetRandomQuestions(request.ExamId);
            var QuestionListMapper = _mapper.Map<List<GetQuestionRandomResponse>>(QuestionList);
            QuestionListMapper.ForEach(a => a.TitleExam=exam.Title);
            QuestionListMapper.ForEach(a => a.Duration=exam.Duration);

            return success(QuestionListMapper);
        }
    }
}
