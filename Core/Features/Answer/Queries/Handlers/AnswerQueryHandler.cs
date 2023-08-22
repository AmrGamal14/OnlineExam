//using AutoMapper;
//using Core.Bases;
//using Core.Features.Answer.Queries.Models;
//using Core.Features.Answer.Queries.Result;
//using Core.Features.Questions.Queries.Models;
//using Core.Features.Questions.Queries.Result;
//using Core.Resources;
//using Infrastructure;
//using Infrastructure.Interfaces;
//using MediatR;
//using Microsoft.Extensions.Localization;
//using Service.Abstracts;
//using Service.Implementations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.Features.Answer.Queries.Handlers
//{
//    public class AnswerQueryHandler : ResponseHandler, IRequestHandler<GetAnswerListQuery, Response<List<GetAnswerListResponse>>>
//    {
//        #region Fields
//        private readonly IUnitOfWorkService _unitOfWorkService;
//        private readonly IMapper _mapper;
//        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
//        #endregion
//        #region Constructors
//        public AnswerQueryHandler(IUnitOfWorkService unitOfWorkService,
//                                    IMapper mapper,
//                                     IStringLocalizer<SharedResources> stringLocalizer)
//        {
//            _unitOfWorkService = unitOfWorkService;
//            _mapper=mapper;
//            _stringLocalizer=stringLocalizer;
//        }
//        #endregion
//        public async Task<Response<List<GetAnswerListResponse>>> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
//        {
//            var AnswerList = await _unitOfWorkService.answerService.GetAnswerByQuestionIdasync(request.QuestionId);
//            var AnswerListMapper = _mapper.Map<List<GetAnswerListResponse>>(AnswerList);
//            return success(AnswerListMapper);
//        }



//    }
//}
