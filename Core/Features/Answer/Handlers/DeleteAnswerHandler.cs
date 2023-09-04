using AutoMapper;
using Application.Bases;
using Application.Features.Answer.Command.Models;
using Application.SharedHandlers;
using MediatR;
using Service.Abstracts;
using Infrastructure.Abstracts;

namespace Application.Features.Answer.Handlers
{
    public class DeleteAnswerHandler : ResponseHandler , IRequestHandler<DeleteAnswerCommand, Response<string>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public DeleteAnswerHandler(IUnitOfWork unitOfWork, IMapper mapper)/*:base(unitOfWorkService,mapper)*/
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer =  _unitOfWork.answer.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault();
            if (answer==null)
                return NotFound<string>("NotFound This Answer");
            await _unitOfWork.answer.DeleteAsync(answer);
            return success("Delete Successfully");
        }
    }
}
