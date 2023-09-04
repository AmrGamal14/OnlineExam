﻿using Application.Features.Subjects.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects.Commands.Validations
{
    public class EditSubjectValidator : AbstractValidator<EditSubjectCommand>

    {
        #region Fields
        public EditSubjectValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be Null");
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

