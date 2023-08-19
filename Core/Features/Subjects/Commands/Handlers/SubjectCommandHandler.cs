using AutoMapper;
using Core.Bases;
using Core.Extensions;
using Core.Features.Subjects.Commands.Models;
using Core.Resources;
using Data.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Commands.Handlers
{
    public class SubjectCommandHandler : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<string>>
                                                        , IRequestHandler<EditSubjectCommand, Response<string>>
                                                        , IRequestHandler<DeleteSubjectCommand, Response<string>>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public SubjectCommandHandler(ISubjectService subjectService , IMapper mapper)

        {
            _subjectService = subjectService;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _subjectService.GetSubjectByIdasync(request.Id);
            if (subject==null) 
                return NotFound<string>("Notfouund");
            var result = await _subjectService.DeleteAsync(subject);
            return success("");
        }

        public async Task<Response<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var oldSubject = await _subjectService.GetSubjectByIdasync(request.Id);
            if (oldSubject == null)
                return NotFound<string>("NotFouund");
            var Subjectmapper = _mapper.Map<Subject>(request);
            var result = await _subjectService.EditAsync(Subjectmapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var SubjectMapper = _mapper.Map<Subject>(request);
            SubjectMapper.AddEntityAudit();
            var result = await _subjectService.AddAsync(SubjectMapper);
            return success(result);
        }
    }
}
