using Application.Bases;
using Application.Features.Exams.Queries.Models;
using Application.Features.Exams.Queries.Result;
using AutoMapper;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Features.Exams.Handlers
{
    public class GetExamListHandler : ResponseHandler, IRequestHandler<GetExamListQuery, Response<List<GetExamListResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;
        #endregion
        #region Constructors
        public GetExamListHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                     IAuditService auditService)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
            _auditService=auditService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetExamListResponse>>> Handle(GetExamListQuery request, CancellationToken cancellationToken)
        {
            var subjectlevel = await _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(request.LevelId);
            var ExamList = await _unitOfWork.exam.GetExamsListAsync(_auditService.UserId, subjectlevel.Id);
            var ExamListMapper = _mapper.Map<List<GetExamListResponse>>(ExamList);
            return success(ExamListMapper);
        }
        #endregion
    }
}
