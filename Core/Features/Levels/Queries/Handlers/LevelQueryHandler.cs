//using AutoMapper;
//using Application.Bases;
//using Application.Features.Levels.Queries.Models;
//using Application.Features.Levels.Queries.Results;
//using Application.Features.Subjects.Queries.Models;
//using Application.Features.Subjects.Queries.Result;
//using Application.Resources;
//using MediatR;
//using Microsoft.Extensions.Localization;
//using Service.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.Levels.Queries.Handlers
//{
//    public  class LevelQueryHandler : ResponseHandler, IRequestHandler<GetLevelListBySubjectIdQuery, Response<List<GetLevelListResponse>>>
//    {
//        #region Fields
//        private readonly IUnitOfWorkService _unitOfWorkService;
//        private readonly IMapper _mapper;
//        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
//        #endregion
//        #region Constructors
//        public LevelQueryHandler(IUnitOfWorkService unitOfWorkService,
//                                    IMapper mapper,
//                                     IStringLocalizer<SharedResources> stringLocalizer)
//        {
//            _unitOfWorkService = unitOfWorkService;
//            _mapper=mapper;
//            _stringLocalizer=stringLocalizer;
//        }
//          #endregion

//        public async Task<Response<List<GetLevelListResponse>>> Handle(GetLevelListBySubjectIdQuery request, CancellationToken cancellationToken)
//        {
//            var levellist= await _unitOfWorkService.levelService.GetLevelListBySubjectId(request.SubjectId);
//            var levellistMapper = _mapper.Map<List<GetLevelListResponse>>(levellist);
//            return success(levellistMapper);
//        }
      

//    }
//}
