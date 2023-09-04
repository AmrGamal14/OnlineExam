using Application.Bases;
using Application.Features.Authentication.Command.Models;
using Data.Entities.Helper;
using Data.Entities.Identity;
using Infrastructure.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Handlers
{
    public class RefreshTokenHandler : ResponseHandler , IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
    {
        #region Fields
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructors
        public RefreshTokenHandler(UserManager<User> userManger, SignInManager<User> signInManager, IAuthenticationService authenticationService)
        {
            _userManger = userManger;
            _signInManager=signInManager;
            _authenticationService = authenticationService;

        }
        #endregion
        #region Handle Functions
        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.GetRefreshToken(request.AccessToken, request.RefreshToken);
            return success(result);
        }
        #endregion
    }
}
