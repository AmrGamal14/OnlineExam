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
    public class EditAnswerHandler : ResponseHandler, IRequestHandler<EditAnswerCommand, Response<string>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public EditAnswerHandler(IUnitOfWork unitOfWork, IMapper mapper)/*:base(unitOfWorkService,mapper)*/
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {
            var OldAnswer =  _unitOfWork.answer.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault(); 
            if (OldAnswer == null)
                return NotFound<string>("NotFound This Answer");
            var Answermapper = _mapper.Map<Answers>(request);
            await   _unitOfWork.answer.UpdateAsync(Answermapper);
            return success("Edit Successfully");
            //if (result=="Success")
            //else return BadRequest<string>("Edit Not Successfully");
        }
    }
}
