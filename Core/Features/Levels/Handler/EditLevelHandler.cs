using Application.Bases;
using Application.Features.Levels.Commands.Models;
using AutoMapper;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Levels.Handler
{
    public class EditLevelHandler: ResponseHandler, IRequestHandler<EditLevelCommand, Response<string>>
    {
         
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public EditLevelHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<string>> Handle(EditLevelCommand request, CancellationToken cancellationToken)
        {
            var oldLevel =  _unitOfWork.level.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
            if (oldLevel == null)
                return NotFound<string>("NotFound");
            var Levelmapper = _mapper.Map<Level>(request);
             await _unitOfWork.level.UpdateAsync(Levelmapper);
           return success("Edit Successfully");
        }
    }
}
