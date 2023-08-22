using AutoMapper;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedHandler
{
    public class SharedHandler
    {
        public readonly IUnitOfWorkService _unitOfWorkService;
        public readonly IMapper _mapper;
        public SharedHandler(IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;

        }
    }


}
