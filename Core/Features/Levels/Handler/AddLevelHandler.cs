using Application.Bases;
using Application.Features.Levels.Commands.Models;
using AutoMapper;
using Data.DTO;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using MediatR;

namespace Application.Features.Levels.Handler
{
    public class AddLevelHandler : ResponseHandler, IRequestHandler<AddLevelCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public AddLevelHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(AddLevelCommand request, CancellationToken cancellationToken)
        {
            var levellist = await _unitOfWork.level.GetLevelBySubjectId(request.SubjectId, request.Name);
            if (levellist!=null) return BadRequest<string>("Level is exist");
            var LevelMapper = _mapper.Map<Level>(request);
            var result = await _unitOfWork.level.AddAsync(LevelMapper);
            SubjectLevelList FormattingSL = new();
            FormattingSL.SubjectId = request.SubjectId;
            FormattingSL.LevelId = result.Id;
            var SubjectLevelMapper = _mapper.Map<SubjectLevel>(FormattingSL);

            var Result = await _unitOfWork.subjectLevel.AddAsync(SubjectLevelMapper);
            return success("Create Successfully");
        }
    }
}
