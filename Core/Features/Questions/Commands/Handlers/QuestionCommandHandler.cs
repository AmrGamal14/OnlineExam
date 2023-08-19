using AutoMapper;
using Core.Bases;
using Core.Extensions;
using Core.Features.Questions.Commands.Models;
using Data.Entities.Models;
using Data.Utils;
using MediatR;
using Service.Abstracts;

namespace Core.Features.Questions.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler, IRequestHandler<AddQuestionAndAnswerCommand, Response<string>>
                                                         , IRequestHandler<EditQuestionCommand, Response<string>>
                                                        , IRequestHandler<DeleteQuestionCommand, Response<string>>
    {
        #region Fields
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public QuestionCommandHandler(IQuestionService questionService, IAnswerService answerService, ISkillService skillService, IMapper mapper)

        {
            _questionService = questionService;
            _answerService = answerService;
            _skillService = skillService;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(AddQuestionAndAnswerCommand request, CancellationToken cancellationToken)
        {
            var skill = await _skillService.GetByEnum(request.SkillName);
            QuestionList FormattingSL = new();
            FormattingSL.Title = request.Title;
            FormattingSL.Description = request.Description;
            FormattingSL.Questions = request.Questions;
            FormattingSL.SubjectLevelId = request.SubjectLevelId;
            FormattingSL.SkillId = skill.Id;
            var QuestionMapper = _mapper.Map<Question>(FormattingSL);
            QuestionMapper.AddEntityAudit();
            var Result = await _questionService.AddAsync(QuestionMapper);
            var answerMap = _mapper.Map<List<Answers>>(request.AnswersList);
            answerMap.ForEach(qId => qId.QuestionId = Result.Id);
            var result= await _answerService.AddListAsync(answerMap);

            return success("k");




        }

        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var OldQuestion = await _questionService.GetQuesyionByIdasync(request.Id);
            if (OldQuestion == null)
                return NotFound<string>("NotFouund");
            var skill = await _skillService.GetByEnum(request.SkillName);
            var Questionmapper = _mapper.Map<Question>(request);
            Questionmapper.SkillId = skill.Id;
            Questionmapper.UpdateEntityAudit();
            var result = await _questionService.EditAsync(Questionmapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionService.GetQuesyionByIdasync(request.Id);
            if (question==null)
                return NotFound<string>("Notfouund");
            var result = await _questionService.DeleteAsync(question);
            return success("");
        }
    }
}
