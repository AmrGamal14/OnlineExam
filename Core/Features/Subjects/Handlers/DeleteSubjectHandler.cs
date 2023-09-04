using Application.Bases;
using Application.Features.Subjects.Commands.Models;
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
    public class DeleteSubjectHandler : ResponseHandler, IRequestHandler<DeleteSubjectCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public DeleteSubjectHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject =  _unitOfWork.subject.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault();
            if (subject==null)
                return NotFound<string>("NotFound");
            await _unitOfWork.subject.DeleteAsync(subject);
            return success("Delete Successfully");
        }
    }
}
