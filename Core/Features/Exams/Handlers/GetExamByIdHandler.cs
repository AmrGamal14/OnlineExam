using Application.Bases;
using Application.Features.Exams.Queries.Models;
using Application.Features.Exams.Queries.Result;
using Application.Resources;
using AutoMapper;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;

namespace Application.Features.Exams.Handlers
{
    public class GetExamByIdHandler : ResponseHandler, IRequestHandler<GetExamByIdQuery, Response<GetExamResponse>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion
        #region Constructors
        public GetExamByIdHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<GetExamResponse>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var Exam =  _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
            var ExamMapper = _mapper.Map<GetExamResponse>(Exam);
            return success(ExamMapper);
        }
        #endregion
    }
}
