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
    public class EditSubjectHandler : ResponseHandler, IRequestHandler<EditSubjectCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public EditSubjectHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var oldSubject =  _unitOfWork.subject.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault();
            if (oldSubject == null)
                return NotFound<string>("NotFound");
            var Subjectmapper = _mapper.Map<Subject>(request);
            Subjectmapper.AddEntityAudit();
            Subjectmapper.UpdateEntityAudit();
          await _unitOfWork.subject.UpdateAsync(Subjectmapper);
            return success("Edit Successfully");
        }
    }
}
