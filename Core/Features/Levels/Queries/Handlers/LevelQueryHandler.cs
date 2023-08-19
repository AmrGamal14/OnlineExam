using AutoMapper;
using Core.Bases;
using Core.Features.Levels.Queries.Models;
using Core.Features.Levels.Queries.Results;
using Core.Features.Subjects.Queries.Models;
using Core.Features.Subjects.Queries.Result;
using Core.Resources;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Queries.Handlers
{
    public class LevelQueryHandler : ResponseHandler, IRequestHandler<GetLevelListBySubjectIdQuery, Response<List<GetLevelListResponse>>>
    {
        #region Fields
        private readonly ILevelService _levelService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public LevelQueryHandler(ILevelService levelService,
                                    IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer)
        {
            _levelService=levelService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
        }
          #endregion

        public async Task<Response<List<GetLevelListResponse>>> Handle(GetLevelListBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            var levellist= await _levelService.GetLevelListBySubjectId(request.SubjectId);
            var levellistMapper = _mapper.Map<List<GetLevelListResponse>>(levellist);
            return success(levellistMapper);
        }
      

    }
}
