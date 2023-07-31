using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Core.Features.Authorization.Commands.Models;
using Service.Abstracts;

namespace Core.Features.Authorization.Commands.Validators
{
    internal class AddRoleValidators : AbstractValidator<AddRoleCommand>

    {
        private readonly IAuthorizationService _authorizationService;
        #region Fields
        public AddRoleValidators(IAuthorizationService authorizationService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _authorizationService=authorizationService;

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be Null");

            
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExist(Key))
                .WithMessage("Failed");

        }
        #endregion
    
    }
}
