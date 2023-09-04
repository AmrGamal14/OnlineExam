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
    internal class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
       

        #region constructors
        public DeleteUserValidator()
        {
           
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Id Must Not Be Empty")
              .NotNull().WithMessage("Id Must Not Be Null");
           

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
