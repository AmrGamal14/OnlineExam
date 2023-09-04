using Application.Bases;
using Application.Features.Questions.Commands.Models;
using AutoMapper;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Handlers
{
    public class DeleteQuestionHandler : ResponseHandler, IRequestHandler<DeleteQuestionCommand, Response<string>>
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public DeleteQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question =  _unitOfWork.question.GetTableNoTracking().Where(x => x.Id == request.Id).FirstOrDefault();
            if (question==null)
                return NotFound<string>("Notfouund");
            await _unitOfWork.question.DeleteAsync(question);
            return success("Delete Successfully");
        }
    }
}
