using Application.Bases;
using Application.Extensions;
using Application.Features.Subjects.Commands.Models;
using AutoMapper;
using Data.Entities.Models;
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
    public class AddSubjectHandler : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public AddSubjectHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var oldsubject =  _unitOfWork.subject.GetTableNoTracking().Where(x => x.Name==request.Name&&x.CreatedBy==_auditService.UserId).FirstOrDefault();
            if (oldsubject != null) return BadRequest<string>("Subject is exist");
            var SubjectMapper = _mapper.Map<Subject>(request);
            SubjectMapper.AddEntityAudit();
            var result = await _unitOfWork.subject.AddAsync(SubjectMapper);
            return success("Create Successfully");
        }
    }
}
