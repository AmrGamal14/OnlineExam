using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserCQRS.Command.Models;
using Application.Resources;
using Microsoft.Extensions.Localization;

namespace Application.Features.UserCQRS.Command.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region constructors
        public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
              .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.FullName]);
            RuleFor(x => x.UserName)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.UserName]);
            RuleFor(x => x.Email)
               .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Email]);
            RuleFor(x => x.Password)
               .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Password]);
            RuleFor(x => x.ConfirmPassword)
               .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.ConfirmPassword])
               .Equal(x=>x.Password).WithMessage(_stringLocalizer[SharedResourcesKeys.ConfirmPasswordEnter]);

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion

    }
}
