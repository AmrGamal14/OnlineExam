using AutoMapper;
using Core.Bases;
using Core.Features.Levels.Commands.Models;
using Core.Features.Subjects.Commands.Models;
using Data.Entities.Models;
using Data.Utils;
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
        private readonly ILevelService _levelService;
        private readonly ISubjectLevelService _subjectLevelService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public LevelCommandHandler(ILevelService levelService, ISubjectLevelService subjectLevelService, IMapper mapper)

        {
            _subjectLevelService = subjectLevelService;
            _levelService = levelService;
            _mapper = mapper;
        }
        #endregion
    
        public async Task<Response<string>> Handle(AddLevelCommand request, CancellationToken cancellationToken)
        {

            var LevelMapper = _mapper.Map<Level>(request);
            var result = await _levelService.AddAsync(LevelMapper);
            SubjectLevelList FormattingSL = new();
            FormattingSL.SubjectId = request.SubjectId;
            FormattingSL.LevelId = result.Id;
            var SubjectLevelMapper = _mapper.Map<SubjectLevel>(FormattingSL);

            var Result = await _subjectLevelService.AddAsync(SubjectLevelMapper);
            return success("k");
        }

        public async Task<Response<string>> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var level = await _levelService.GetLevelByIdasync(request.Id);
            if (level==null) return NotFound<string>("Notfouund");
            var result = await _levelService.DeleteAsync(level);
            return success("");
        }
        public async Task<Response<string>> Handle(EditLevelCommand request, CancellationToken cancellationToken)
        {
            var oldLevel = await _levelService.GetLevelByIdasync(request.Id);
            if (oldLevel == null)
                return NotFound<string>("NotFouund");
            var Levelmapper = _mapper.Map<Level>(request);
            var result = await _levelService.EditAsync(Levelmapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }
    }
}
