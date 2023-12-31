﻿using Application.Bases;
using Application.Extensions;
using Application.Features.Questions.Commands.Models;
using Application.Features.Questions.Queries.Models;
using Application.Features.Questions.Queries.Result;
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

namespace Application.Features.Questions.Handlers
{
    public class EditQuestionHandler : ResponseHandler, IRequestHandler<EditQuestionCommand, Response<string>>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public EditQuestionHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var OldQuestion = _unitOfWork.question.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault();
            if (OldQuestion == null)
                return NotFound<string>("NotFouund");
            var skill = await _unitOfWork.skill.GetByEnum(request.SkillName);
            var Questionmapper = _mapper.Map<Question>(request);
            Questionmapper.SkillId = skill.Id;
            Questionmapper.SubjectLevelId = OldQuestion.SubjectLevelId;
            Questionmapper.AddEntityAudit();
            Questionmapper.UpdateEntityAudit();
            await _unitOfWork.question.UpdateAsync(Questionmapper);
            return success("Edit Successfully");
        }
       
    }
}
