﻿using Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Features.Authorization.Commands.Models;
using Service.Abstracts;

namespace Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand,Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;
     
        public RoleCommandHandler(IAuthorizationService authorizationService)
        {
         _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result =await  _authorizationService.AddRoleAsync(request.RoleName);
            if (result=="Success") return success(result);
            return BadRequest<string>();

        }
    }
}
