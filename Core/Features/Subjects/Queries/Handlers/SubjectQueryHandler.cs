//using AutoMapper;
//using Application.Bases;
//using Application.Features.Subjects.Queries.Models;
//using Application.Features.Subjects.Queries.Result;
//using Application.Resources;
//using Infrastructure.Interfaces;
//using MediatR;
//using Microsoft.Extensions.Localization;
//using Service.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.Subjects.Queries.Handlers
//{
//    public class SubjectQueryHandler : ResponseHandler, IRequestHandler<GetSubjectListQuery, Response<List<GetSubjectListResponse>>>
//    {
//        #region Fields
//        private readonly IUnitOfWorkService _unitOfWorkService;
//        private readonly IMapper _mapper;
//        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
//        private readonly IAuditService _auditService;
//        #endregion
//        #region Constructors
//        public SubjectQueryHandler(IUnitOfWorkService unitOfWorkService,
//                                    IMapper mapper,
//                                     IStringLocalizer<SharedResources> stringLocalizer,
//                                     IAuditService auditService)
//        {
//            _unitOfWorkService = unitOfWorkService;
//            _mapper=mapper;
//            _stringLocalizer=stringLocalizer;
//            _auditService=auditService;
//        }
//        #endregion
//        #region Handle Functions
//        public async Task<Response<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
//        {
//            var subjectList = await _unitOfWorkService.subjectService.GetSubjectsListAsync(_auditService.UserId);
//            var SubjectListMapper = _mapper.Map<List<GetSubjectListResponse>>(subjectList);
//            return success(SubjectListMapper);
//        }
//        #endregion
//    }
//}
