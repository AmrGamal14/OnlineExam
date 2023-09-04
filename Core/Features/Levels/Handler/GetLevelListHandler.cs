using Application.Bases;
using Application.Features.Levels.Queries.Models;
using Application.Features.Levels.Queries.Results;
using AutoMapper;
using Infrastructure.Abstracts;
using MediatR;

namespace Application.Features.Levels.Handler
{
    public class GetLevelListHandler :ResponseHandler, IRequestHandler<GetLevelListBySubjectIdQuery, Response<List<GetLevelListResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetLevelListHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetLevelListResponse>>> Handle(GetLevelListBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            var levellist = await _unitOfWork.level.GetLevelListBySubjectId(request.SubjectId);
            var levellistMapper = _mapper.Map<List<GetLevelListResponse>>(levellist);
            return success(levellistMapper);
        }
    }
}
