using AutoMapper;
using Core.Bases;
using Core.Extensions;
using Core.Features.Questions.Commands.Models;
using Data.Entities.Models;
using Data.DTO;
using MediatR;
using Service.Abstracts;
using Service.Implementations;

namespace Core.Features.Questions.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler, IRequestHandler<AddQuestionAndAnswerCommand, Response<string>>
                                                         , IRequestHandler<EditQuestionCommand, Response<string>>
                                                        , IRequestHandler<DeleteQuestionCommand, Response<string>>
    {
        #region Fields
        //private readonly IQuestionService _questionService;
        //private readonly IAnswerService _answerService;
        //private readonly ISkillService _skillService;
        //private readonly ISubjectLevelService _subjectLevelService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public QuestionCommandHandler(IUnitOfWorkService unitOfWorkService, IMapper mapper)

        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(AddQuestionAndAnswerCommand request, CancellationToken cancellationToken)
        {
            var subjectlevel = await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);
            if (subjectlevel == null)
                return NotFound<string>("NotFouund");
            var answerlist = request.AnswersLists.FirstOrDefault(q => q.IsCorrect==true);
            if (answerlist==null)
                return BadRequest<string>("Answers Must Includ answer equal true");
            int countt =request.AnswersLists.Count();
            if (countt<=1) return BadRequest<string>("Answer must be more then one");
            var skill = await _unitOfWorkService.skillService.GetByEnum(request.SkillName);
            QuestionList FormattingSL = new();
            FormattingSL.Title = request.Title;
            FormattingSL.Description = request.Description;
            FormattingSL.Questions = request.Questions;
            FormattingSL.SubjectLevelId = subjectlevel.Id;
            FormattingSL.SkillId = skill.Id;
            var QuestionMapper = _mapper.Map<Question>(FormattingSL);
            QuestionMapper.AddEntityAudit();
            var Result = await _unitOfWorkService.questionService.AddAsync(QuestionMapper);
            var answerMap = _mapper.Map<List<Answers>>(request.AnswersLists);
            answerMap.ForEach(qId => qId.QuestionId = Result.Id);
            var result= await _unitOfWorkService.answerService.AddListAsync(answerMap);

            return success("k");




        }

        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var OldQuestion = await _unitOfWorkService.questionService.GetQuesyionByIdasync(request.Id);
            if (OldQuestion == null)
                return NotFound<string>("NotFouund");
            var skill = await _unitOfWorkService.skillService.GetByEnum(request.SkillName);
            var Questionmapper = _mapper.Map<Question>(request);
            Questionmapper.SkillId = skill.Id;
            Questionmapper.SubjectLevelId = OldQuestion.SubjectLevelId;
            Questionmapper.AddEntityAudit();
            Questionmapper.UpdateEntityAudit();
            var result = await _unitOfWorkService.questionService.EditAsync(Questionmapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWorkService.questionService.GetQuesyionByIdasync(request.Id);
            if (question==null)
                return NotFound<string>("Notfouund");
            var result = await _unitOfWorkService.questionService.DeleteAsync(question);
            return success("");
        }
    }
}
