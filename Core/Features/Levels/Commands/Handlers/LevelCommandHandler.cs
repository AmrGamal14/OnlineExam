using AutoMapper;
using Core.Bases;
using Core.Features.Levels.Commands.Models;
using Core.Features.Subjects.Commands.Models;
using Data.Entities.Models;
using Data.DTO;
using MediatR;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Commands.Handlers
{
    public class LevelCommandHandler : ResponseHandler, IRequestHandler<AddLevelCommand, Response<string>>
                                                        , IRequestHandler<EditLevelCommand, Response<string>>
                                                        , IRequestHandler<DeleteLevelCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public LevelCommandHandler(IUnitOfWorkService unitOfWorkService, IMapper mapper)

        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }
        #endregion
    
        public async Task<Response<string>> Handle(AddLevelCommand request, CancellationToken cancellationToken)
        {
            var levellist = await _unitOfWorkService.levelService.GetLevelBySubjectId(request.SubjectId,request.Name);
            if (levellist!=null)return BadRequest<string>("Level is exist");
            var LevelMapper = _mapper.Map<Level>(request);
            var result = await _unitOfWorkService.levelService.AddAsync(LevelMapper);
            SubjectLevelList FormattingSL = new();
            FormattingSL.SubjectId = request.SubjectId;
            FormattingSL.LevelId = result.Id;
            var SubjectLevelMapper = _mapper.Map<SubjectLevel>(FormattingSL);

            var Result = await _unitOfWorkService.subjectLevelService.AddAsync(SubjectLevelMapper);
            return success("k");
        }

        public async Task<Response<string>> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var level = await _unitOfWorkService.levelService.GetLevelByIdasync(request.Id);
            if (level==null) return NotFound<string>("Notfouund");
            var result = await _unitOfWorkService.levelService.DeleteAsync(level);
            return success("");
        }
        public async Task<Response<string>> Handle(EditLevelCommand request, CancellationToken cancellationToken)
        {
            var oldLevel = await _unitOfWorkService.levelService.GetLevelByIdasync(request.Id);
            if (oldLevel == null)
                return NotFound<string>("NotFouund");
            var Levelmapper = _mapper.Map<Level>(request);
            var result = await _unitOfWorkService.levelService.EditAsync(Levelmapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }
    }
}
