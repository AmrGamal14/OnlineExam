using Application.Bases;
using Application.Features.Subjects.Queries.Models;
using Application.Features.Subjects.Queries.Result;
using AutoMapper;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects.Handlers
{
    public class GetSubjectListHandler : ResponseHandler, IRequestHandler<GetSubjectListQuery, Response<List<GetSubjectListResponse>>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetSubjectListHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var subjectList = await _unitOfWork.subject.GetSubjectListAscync(_auditService.UserId);
            var SubjectListMapper = _mapper.Map<List<GetSubjectListResponse>>(subjectList);
            return success(SubjectListMapper);
        }
        #endregion
    }
}
