﻿using Core.Features.Levels.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Commands.Validations
{
    internal class DeleteLevelValidator : AbstractValidator<DeleteLevelCommand>

    {
        #region Fields
        public DeleteLevelValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Must not Be Empty")
                .NotNull().WithMessage("Id Must not Be Null");

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
