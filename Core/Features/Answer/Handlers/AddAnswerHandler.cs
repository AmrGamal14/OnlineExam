using AutoMapper;
using Application.Bases;
using Application.Features.Answer.Command.Models;
using Application.SharedHandlers;
using Data.Entities.Models;
using MediatR;
using Service.Abstracts;
using Infrastructure.Abstracts;

namespace Application.Features.Answer.Handlers
{
    public class AddAnswerHandler : ResponseHandler, IRequestHandler<AddAnswerCommand, Response<string>>
    {
        
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public AddAnswerHandler(IUnitOfWork unitOfWork,IMapper mapper)/*:base(unitOfWorkService,mapper)*/
        {
           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = _mapper.Map<Answers>(request);
            var result = await _unitOfWork.answer.AddAsync(AnswerMapper);
            return success("Create Successfully");

        }
    }
}
