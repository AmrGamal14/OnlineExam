using AutoMapper;
using Application.Bases;
using Application.Features.Answer.Queries.Models;
using Application.Features.Answer.Queries.Result;
using Application.SharedHandlers;
using MediatR;
using Service.Abstracts;
using Infrastructure.Abstracts;

namespace Application.Features.Answer.Handlers
{
    public class GetAnswerListHandler : ResponseHandler, IRequestHandler<GetAnswerListQuery, Response<List<GetAnswerListResponse>>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetAnswerListHandler(IUnitOfWork unitOfWork, IMapper mapper)/*:base(unitOfWorkService,mapper)*/
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Response<List<GetAnswerListResponse>>> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
        {
            var AnswerList = await _unitOfWork.answer.GetAnswerListByQuestionId(request.QuestionId);
            var AnswerListMapper = _mapper.Map<List<GetAnswerListResponse>>(AnswerList);
            return success(AnswerListMapper);
        }
    }
}
