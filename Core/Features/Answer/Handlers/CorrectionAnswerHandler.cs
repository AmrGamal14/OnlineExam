using AutoMapper;
using Application.Bases;
using Application.Features.Answer.Command.Models;
using Application.SharedHandlers;
using Data.DTO;
using Data.Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Service.Abstracts;
using Infrastructure.Abstracts;

namespace Application.Features.Answer.Handlers
{
    public class CorrectionAnswerHandler : ResponseHandler, IRequestHandler<CorrectionAnswerCommand, Response<string>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IAuditService _auditService;
        public readonly IMapper _mapper;
        public CorrectionAnswerHandler(IUnitOfWork unitOfWork, IMapper mapper,IAuditService auditService)/*:base(unitOfWorkService,mapper)*/
        {
            _unitOfWork = unitOfWork;
            _auditService = auditService;
            _mapper = mapper;

        }
        public async Task<Response<string>> Handle(CorrectionAnswerCommand request, CancellationToken cancellationToken)
        {
            var Answers = await _unitOfWork.answer.GetByMultipleIdsAsync(request.correctLists.Select(a => a.AnswerId).ToList());
            if (Answers.Count == 0)
                return BadRequest<string>("no answers found");
            var correctAnswers = Answers.Where(a => a.IsCorrect == true);
            var Score = correctAnswers.Count();
            var answerlist = new List<AnswerList>();
            foreach(var x in Answers)
            {
                answerlist.Add(new AnswerList{
                    AnswerId=x.Id,
                    IsCorrect=x.IsCorrect
                });
            }
            ScoreExam FormattingSL = new();
            FormattingSL.ExamId=request.ExamId;
            FormattingSL.ExamDate=DateTime.UtcNow;
            FormattingSL.UserId=  Guid.Parse(_auditService.UserId);
            FormattingSL.Score=Score;
            var StudentExamMapper = _mapper.Map<StudentExam>(FormattingSL);
            var Result = await _unitOfWork.studentExam.AddAsync(StudentExamMapper);
            var ExamQuestionMap = _mapper.Map<List<ExamQuestion>>(request.correctLists);
            ExamQuestionMap.ForEach(qId => qId.StudentExamId = Result.Id);
            var result = await _unitOfWork.examQuestion.AddListAsync(ExamQuestionMap);
            var StudentExamResultMap = _mapper.Map<List<StudentExamResult>>(answerlist);
            StudentExamResultMap.ForEach(qId => qId.StudentExamId = Result.Id);

            //var StudentExamResult = answerlist.Select(a => MapAnswerIds(a, Result.Id)).ToList();
            var StudentResult = await _unitOfWork.studentResult.AddListAsync(StudentExamResultMap);
            return success($"Your score is :{Score}");

        }
        //public StudentExamResult MapAnswerIds(AnswerList answerList, Guid Id)
        //{
        //    return new StudentExamResult
        //    {
        //        AnswerId = answerList.AnswerId,
        //        IsCorrect = answerList.IsCorrect,
        //        StudentExamId = Id
        //    };
        
    }
}
