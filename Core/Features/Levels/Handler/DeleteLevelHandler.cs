using Application.Bases;
using Application.Features.Levels.Commands.Models;
using AutoMapper;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Levels.Handler
{
    public class DeleteLevelHandler : ResponseHandler, IRequestHandler<DeleteLevelCommand, Response<string>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public DeleteLevelHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var level =  _unitOfWork.level.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
            if (level==null) return NotFound<string>("NotFound");
            await _unitOfWork.level.DeleteAsync(level);
            return success("Delete Successfully");
        }
    }
}
