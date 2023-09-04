//using AutoMapper;
//using Application.Bases;
//using Application.Extensions;
//using Application.Features.Subjects.Commands.Models;
//using Application.Resources;
//using Data.Entities.Models;
//using Infrastructure.Interfaces;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Localization;
//using Service.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.Subjects.Commands.Handlers
//{
//    public class SubjectCommandHandler : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<string>>
//                                                        , IRequestHandler<EditSubjectCommand, Response<string>>
//                                                        , IRequestHandler<DeleteSubjectCommand, Response<string>>
//    {
//        #region Fields
//        private readonly IUnitOfWorkService _unitOfWorkService;
//        private readonly IMapper _mapper;
//        private readonly IAuditService _auditService;
//        #endregion
//        #region Constructors
//        public SubjectCommandHandler(IUnitOfWorkService unitOfWorkService, IAuditService auditService, IMapper mapper)

//        {
//            _auditService=auditService;
//            _unitOfWorkService = unitOfWorkService;
//            _mapper = mapper;
//        }
//        #endregion
//        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
//        {
//            var subject = await _unitOfWorkService.subjectService.GetSubjectByIdasync(request.Id);
//            if (subject==null)
//                return NotFound<string>("NotFound");
//            var result = await _unitOfWorkService.subjectService.DeleteAsync(subject);
//            return success("Delete Successfully");
//        }

//        public async Task<Response<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
//        {
//            var oldSubject = await _unitOfWorkService.subjectService.GetSubjectByIdasync(request.Id);
//            if (oldSubject == null)
//                return NotFound<string>("NotFound");
//            var Subjectmapper = _mapper.Map<Subject>(request);
//            Subjectmapper.AddEntityAudit();
//            Subjectmapper.UpdateEntityAudit();
//            var result = await _unitOfWorkService.subjectService.EditAsync(Subjectmapper);
//            if (result=="Success") return success("Edit Successfully");
//            else return BadRequest<string>("Edit Not Successfully");
//        }

//        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
//        {
//            var oldsubject = await _unitOfWorkService.subjectService.GetSubjectByNameasync(request.Name, _auditService.UserId);
//            if (oldsubject != null) return BadRequest<string>("Subject is exist");
//            var SubjectMapper = _mapper.Map<Subject>(request);
//            SubjectMapper.AddEntityAudit();
//            var result = await _unitOfWorkService.subjectService.AddAsync(SubjectMapper);
//            return success(result);
//        }
//    }
//}
