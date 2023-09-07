using Application.Bases;
using Application.Features.Answer.Queries.Models;
using Application.Features.Answer.Queries.Result;
using Application.Features.Exams.Queries.Models;
using Application.Features.Exams.Queries.Result;
using AutoMapper;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Answer.Handlers
{
    public class GetAnswerByIdHandler : ResponseHandler, IRequestHandler<GetAnswerById, Response<GetAnswerByIdResponse>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion
        #region Constructors
        public GetAnswerByIdHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<GetAnswerByIdResponse>> Handle(GetAnswerById request, CancellationToken cancellationToken)
        {
            var Answer = _unitOfWork.answer.GetTableNoTracking().Where(x => x.Id==request.AnswerId).FirstOrDefault();
            var AnswerMapper = _mapper.Map<GetAnswerByIdResponse>(Answer);
            return success(AnswerMapper);
        }
        #endregion
    }
}
