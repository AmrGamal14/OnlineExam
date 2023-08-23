using AutoMapper;
using Core.Bases;
using Core.Features.Answer.Command.Models;
using Core.Features.Answer.Queries.Models;
using Core.Features.Answer.Queries.Result;
using Core.Features.Questions.Commands.Models;
using Data.DTO;
using Data.Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Handlers
{
    public class AnswerCommandHandler : ResponseHandler, IRequestHandler<EditAnswerCommand, Response<string>>
                                                         , IRequestHandler<DeleteAnswerCommand, Response<string>>
                                                         , IRequestHandler<AddAnswerCommand, Response<string>>
                                                         , IRequestHandler<CorrectionAnswerCommand, Response<string>>
                                                         , IRequestHandler<GetAnswerListQuery, Response<List<GetAnswerListResponse>>>

    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;
        private readonly IAuditService _auditService;
        public AnswerCommandHandler(IUnitOfWorkService unitOfWorkService, IAuditService auditService,IMapper mapper)
        {
            _auditService = auditService;
            _unitOfWorkService = unitOfWorkService;
            _mapper=mapper;

        }

        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {
            var OldAnswer = await _unitOfWorkService.answerService.GetAnswerByIdasync(request.Id);
            if (OldAnswer == null)
                return NotFound<string>("NotFouund");
            var Answermapper = _mapper.Map<Answers>(request);
            var result = await _unitOfWorkService.answerService.EditAsync(Answermapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _unitOfWorkService.answerService.GetAnswerByIdasync(request.Id);
            if (answer==null)
                return NotFound<string>("Notfouund");
            var result = await _unitOfWorkService.answerService.DeleteAsync(answer);
            return success("");
        }

        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = _mapper.Map<Answers>(request);
            var result = await _unitOfWorkService.answerService.AddAsync(AnswerMapper);
            return success("k");

        }
        public async Task<Response<List<GetAnswerListResponse>>> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
        {
            var AnswerList = await _unitOfWorkService.answerService.GetAnswerByQuestionIdasync(request.QuestionId);
            var AnswerListMapper = _mapper.Map<List<GetAnswerListResponse>>(AnswerList);
            return success(AnswerListMapper);
        }

        public async Task<Response<string>> Handle(CorrectionAnswerCommand request, CancellationToken cancellationToken)
        {
            var Answers = await _unitOfWorkService.answerService.GetByMultipleIdsAsync(request.correctLists.Select(a => a.AnswerId).ToList());
            if (Answers.Count == 0)
                return BadRequest<string>("no answers found");
            var correctAnswers = Answers.Where(a => a.IsCorrect == true);
            var Score = correctAnswers.Count();
            var answerlist = new List<AnswerList>();
            foreach(var x in Answers)
            {
                answerlist.Add(new AnswerList{
                    Id=x.Id,
                    IsCorrect=x.IsCorrect
                });
            }
            ScoreExam FormattingSL = new();
            FormattingSL.ExamId=request.ExamId;
            FormattingSL.ExamDate=DateTime.UtcNow;
            FormattingSL.UserId=  Guid.Parse(_auditService.UserId);
            FormattingSL.Score=Score;
            var StudentExamMapper = _mapper.Map<StudentExam>(FormattingSL);
            var Result = await _unitOfWorkService.studentExamSrevice.AddAsync(StudentExamMapper);
            var ExamQuestionMap = _mapper.Map<List<ExamQuestion>>(request.correctLists);
            ExamQuestionMap.ForEach(qId => qId.StudentExamId = Result.Id);
            var result = await _unitOfWorkService.examQuestionService.AddListAsync(ExamQuestionMap);
            var StudentExamResultMap = _mapper.Map<List<StudentExamResult>>(answerlist);
            StudentExamResultMap.ForEach(qId => qId.StudentExamId = Result.Id);
            var StudentResult = await _unitOfWorkService.studentResultService.AddListAsync(StudentExamResultMap);
            return success($"Your score is :{Score}");

        }
    }
}
