using Application.Bases;
using Application.Features.Exams.Commands.Models;
using Infrastructure.Abstracts;
using MediatR;

namespace Application.Features.Exams.Handlers
{
    public class DeleteExamHandler : ResponseHandler, IRequestHandler<DeleteExamCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExamHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<Response<string>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
            if (exam==null) return NotFound<string>("Notfouund");
            await _unitOfWork.exam.DeleteAsync(exam);
            return success("Delete Successfully");
        }
    }
}
