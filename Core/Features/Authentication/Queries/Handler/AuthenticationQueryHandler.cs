using Core.Bases;
using Core.Features.Authentication.Queries.Models;
using MediatR;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler, IRequestHandler<AuthorizeUserQuery, Response<string>>

    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructors
        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;

        }


        #endregion

        #region Handle Functions


        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return success(result);
            return BadRequest<string>("Expired");
        }
        #endregion
    }

}
