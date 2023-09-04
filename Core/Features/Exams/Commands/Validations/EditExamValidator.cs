using Application.Features.Exams.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Commands.Validations
{
    public class EditExamValidator : AbstractValidator<EditExamCommand>

    {
        #region Fields
        public EditExamValidator()
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
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title Must not Be Empty")
                .NotNull().WithMessage("Title Must not Be Null");
            RuleFor(x => x.QuestionCount)
                .GreaterThanOrEqualTo(1).WithMessage("QuestionCount Must not Be zero or less")
                .NotNull().WithMessage("QuestionCount Must not Be Null");
            RuleFor(x => x.Duration)
                .NotNull().WithMessage("Duration Must not Be Null");
        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
