using Core.Features.Exams.Commands.Models;
using Core.Features.Questions.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Exams.Commands.Validations
{
    public class AddExamValidator : AbstractValidator<AddExamCommand>

    {
        #region Fields
        public AddExamValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title Must not Be Empty")
                .NotNull().WithMessage("Title Must not Be Null");
            RuleFor(x => x.QuestionCount)
                .NotNull().WithMessage("QuestionCount Must not Be Null")
                .GreaterThanOrEqualTo(1).WithMessage("QuestionCount Must not Be zero or less");
            RuleFor(x => x.Duration)
                .NotNull().WithMessage("Duration Must not Be Null");
            RuleFor(x => x.LevelId)
                .NotEmpty().WithMessage("LevelId Must not Be Empty")
                .NotNull().WithMessage("LevelId Must not Be Null");

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
