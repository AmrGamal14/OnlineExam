using Application.Bases;
using Application.Extensions;
using Application.Features.Questions.Commands.Models;
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
        public EditQuestionHandler(IUnitOfWork unitOfWork,IAuditService auditService ,IMapper mapper)

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
            var answerlist = request.Ans.FirstOrDefault(q => q.IsCorrect==true);
            if (answerlist==null)
                return BadRequest<string>("Answers Must Includ answer equal true");
            int countt = request.Ans.Count();
            if (countt<=1) return BadRequest<string>("Answer must be more then one");
            var skill = await _unitOfWork.skill.GetByEnum(request.SkillName);
            var Questionmapper = _mapper.Map<Question>(request);
            Questionmapper.SkillId = skill.Id;
            Questionmapper.SubjectLevelId = OldQuestion.SubjectLevelId;
            Questionmapper.AddEntityAudit();
            Questionmapper.UpdateEntityAudit();
            await _unitOfWork.question.UpdateAsync(Questionmapper);
            var answerMap = _mapper.Map<List<Answers>>(request.Ans);
            answerMap.ForEach(qId => qId.QuestionId = request.Id);
             await _unitOfWork.answer.UpdateListAsync(answerMap);
           return success("Edit Successfully");

        }
    }
}
