using AutoMapper;
using Core.Bases;
using Core.Features.Subjects.Queries.Models;
using Core.Features.Subjects.Queries.Result;
using Core.Resources;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler, IRequestHandler<GetSubjectListQuery, Response<List<GetSubjectListResponse>>>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuditService _auditService;
        #endregion
        #region Constructors
        public SubjectQueryHandler(ISubjectService subjectService,
                                    IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer,
                                     IAuditService auditService)
        {
            _subjectService=subjectService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
            _auditService=auditService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var subjectList = await _subjectService.GetSubjectsListAsync(_auditService.UserId);
            var SubjectListMapper = _mapper.Map<List<GetSubjectListResponse>>(subjectList);
            return success(SubjectListMapper);
        }
        #endregion
    }
}
