using Application.Bases;
using Application.Extensions;
using Application.Features.Exams.Commands.Models;
using AutoMapper;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Service.Abstracts;

namespace Application.Features.Exams.Handlers
{
    public class EditExamHandler : ResponseHandler, IRequestHandler<EditExamCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        public EditExamHandler(IMapper mapper, IAuditService auditService, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _auditService = auditService;
            _unitOfWork= unitOfWork;
        }
        public async Task<Response<string>> Handle(EditExamCommand request, CancellationToken cancellationToken)
        {
            var OldExam = _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
            if (OldExam == null)
                return NotFound<string>("NotFouund");
            var Exammapper = _mapper.Map<Exam>(request);
            Exammapper.AddEntityAudit();
            Exammapper.SubjectLevelId=OldExam.SubjectLevelId;
            Exammapper.url=OldExam.url;
            await _unitOfWork.exam.UpdateAsync(Exammapper);
            return success("Edit Successfully");

        }
    }
}
