using Application.Bases;
using Application.Extensions;
using Application.Features.Questions.Commands.Models;
using AutoMapper;
using Data.DTO;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Handlers
{
    public class AddQuestionAndAnswerHandler : ResponseHandler, IRequestHandler<AddQuestionAndAnswerCommand, Response<string>>
    {
        #region Fields
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public AddQuestionAndAnswerHandler(IUnitOfWork unitOfWork,IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(AddQuestionAndAnswerCommand request, CancellationToken cancellationToken)
        {
            var subjectlevel = await _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(request.LevelId);
            if (subjectlevel == null)
                return NotFound<string>("NotFouund");
            var answerlist = request.AnswersLists.FirstOrDefault(q => q.IsCorrect==true);
            if (answerlist==null)
                return BadRequest<string>("Answers Must Includ answer equal true");
            int countt = request.AnswersLists.Count();
            if (countt<=1) return BadRequest<string>("Answer must be more then one");
            var skill = await _unitOfWork.skill.GetByEnum(request.SkillName);
            QuestionList FormattingSL = new();
            FormattingSL.Title = request.Title;
            FormattingSL.Description = request.Description;
            FormattingSL.Questions = request.Questions;
            FormattingSL.SubjectLevelId = subjectlevel.Id;
            FormattingSL.SkillId = skill.Id;
            var QuestionMapper = _mapper.Map<Question>(FormattingSL);
            QuestionMapper.AddEntityAudit();
            var Result = await _unitOfWork.question.AddAsync(QuestionMapper);
            var answerMap = _mapper.Map<List<Answers>>(request.AnswersLists);
            answerMap.ForEach(qId => qId.QuestionId = Result.Id);
            var result = await _unitOfWork.answer.AddListAsync(answerMap);

            return success("Add Successfully");
        }
    }
}
