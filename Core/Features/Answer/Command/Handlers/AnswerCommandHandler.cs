//using AutoMapper;
//using Core.Bases;
//using Core.Features.Answer.Command.Models;
//using Core.Features.Questions.Commands.Models;
//using Data.Entities.Models;
//using MediatR;
//using Service.Abstracts;
//using Service.Implementations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.Features.Answer.Command.Handlers
//{
//    public class AnswerCommandHandler : ResponseHandler, IRequestHandler<EditAnswerCommand, Response<string>>
//                                                         , IRequestHandler<DeleteAnswerCommand, Response<string>>
//                                                         , IRequestHandler<AddAnswerCommand, Response<string>>

//    {
//        private readonly IUnitOfWorkService _unitOfWorkService;
//        private readonly IMapper _mapper;
//        public AnswerCommandHandler(IUnitOfWorkService unitOfWorkService, IMapper mapper)
//        {
//            _unitOfWorkService = unitOfWorkService;
//            _mapper=mapper;

//        }

//        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
//        {
//            var OldAnswer = await _unitOfWorkService.answerService.GetAnswerByIdasync(request.Id);
//            if (OldAnswer == null)
//                return NotFound<string>("NotFouund");
//            var Answermapper = _mapper.Map<Answers>(request);
//            var result = await _unitOfWorkService.answerService.EditAsync(Answermapper);
//            if (result=="Success") return success("Edit Successfully");
//            else return BadRequest<string>();
//        }

//        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
//        {
//            var answer = await _unitOfWorkService.answerService.GetAnswerByIdasync(request.Id);
//            if (answer==null)
//                return NotFound<string>("Notfouund");
//            var result = await _unitOfWorkService.answerService.DeleteAsync(answer);
//            return success("");
//        }

//        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
//        {
//            var AnswerMapper = _mapper.Map<Answers>(request);
//            var result = await _unitOfWorkService.answerService.AddAsync(AnswerMapper);
//            return success("k");

//        }
//    }
//}
