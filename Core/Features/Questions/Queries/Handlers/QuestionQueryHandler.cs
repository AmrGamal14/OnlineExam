//using AutoMapper;
//using Application.Bases;
//using Application.Features.Questions.Queries.Models;
//using Application.Features.Questions.Queries.Result;
//using Application.Resources;
//using Infrastructure.Interfaces;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Localization;
//using Service.Abstracts;

//namespace Application.Features.Questions.Queries.Handlers
//{
//    public class QuestionQueryHandler : ResponseHandler, IRequestHandler<GetQuestionListQuery, Response<List<GetQuestionListResponse>>>
//                                                          , IRequestHandler<GetQuestionRandom, Response<List<GetQuestionRandomResponse>>>
//                                                          , IRequestHandler<GetQuestionAndAnswerById, Response<GetByIdResponse>>
//    {
//        #region Fields

//        private static IUnitOfWorkService _unitOfWorkService;
//        private readonly IAuditService _auditService;
//        private static IServiceScopeFactory _serviceProvider;
//        private readonly IMapper _mapper;
//        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
//        #endregion
//        #region Constructors
//        public QuestionQueryHandler(IUnitOfWorkService unitOfWorkService,
//                                    IMapper mapper,
//                                  IServiceScopeFactory serviceScope,
//                                    IAuditService auditService,
//                                     IStringLocalizer<SharedResources> stringLocalizer)
//        {
//            _unitOfWorkService = unitOfWorkService;
//            _mapper=mapper;
//            _serviceProvider = serviceScope;
//            _auditService=auditService;
//            _stringLocalizer=stringLocalizer;
//        }

//        public async Task<Response<List<GetQuestionListResponse>>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
//        {

//            var subjectlevel = await _unitOfWorkService.subjectLevelService.GetSubjectLevelByLevelIdasync(request.LevelId);
//            var QuestionList = await _unitOfWorkService.questionService.GetQuestionListAsync(_auditService.UserId,subjectlevel.Id);
//             var QuestionListMapper = _mapper.Map<List<GetQuestionListResponse>>(QuestionList);
//            return success(QuestionListMapper);
//        }

//        public async Task<Response<List<GetQuestionRandomResponse>>> Handle(GetQuestionRandom request, CancellationToken cancellationToken)
//        {
//            var exam = await _unitOfWorkService.examService.GetByIdasync(request.ExamId);
//            var QuestionList = await _unitOfWorkService.questionService.GetQuestionRandomAsync(request.ExamId);
//            var QuestionListMapper = _mapper.Map<List<GetQuestionRandomResponse>>(QuestionList);
//            QuestionListMapper.ForEach(a => a.TitleExam=exam.Title);
//            QuestionListMapper.ForEach(a => a.Duration=exam.Duration);

//            return success(QuestionListMapper);
//        }

//        public async Task<Response<GetByIdResponse>> Handle(GetQuestionAndAnswerById request, CancellationToken cancellationToken)
//        {
//            var question = await _unitOfWorkService.questionService.GetQuestionandAnswerById(request.Id);
//            var questionmapper = _mapper.Map<GetByIdResponse>(question);
//            return success(questionmapper);

//        }
//        #endregion

//    }
//}
