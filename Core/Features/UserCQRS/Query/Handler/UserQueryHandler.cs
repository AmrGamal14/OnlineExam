using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bases;
using Application.Features.UserCQRS.Query.Models;
using Application.Features.UserCQRS.Query.Result;
using Application.Wrappers;
using Data.Entities.Identity;

namespace Application.Features.UserCQRS.Query.Handler
{
    public class UserQueryHandler : ResponseHandler ,
                 IRequestHandler<GetUserListQuery,PaginatedResult<GetUserListResult>>
    {
        #region Feilds
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructor
        public UserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        #endregion
        #region handle function
        public async Task<PaginatedResult<GetUserListResult>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserListResult>(users).ToPaginatedListAsynnc(request.PageNumber, request.PageSize);
            return paginatedList;
        }
        #endregion
    }
}
