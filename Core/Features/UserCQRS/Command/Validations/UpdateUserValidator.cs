using Application.Features.UserCQRS.Command.Models;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserCQRS.Command.Validations
{

    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region constructors
        public UpdateUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
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
            RuleFor(x => x.PhoneNumber)
               .NotNull().WithMessage("PhoneNumber Must Not Be Null");
             
    }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion

    }
}
