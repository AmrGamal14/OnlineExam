using AutoMapper;
using Application.Bases;
using Infrastructure.Interfaces;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SharedHandlers
{
    public abstract class SharedHandler :ResponseHandler
    {
        public readonly IUnitOfWorkService _unitOfWorkService;
        public readonly IMapper _mapper;
        public readonly IAuditService _auditService;
        public SharedHandler(IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            
            _mapper = mapper;
        }

    }


}
