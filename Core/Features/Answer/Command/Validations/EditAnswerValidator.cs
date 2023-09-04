using Application.Features.Answer.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Answer.Command.Validations
{
    public class EditAnswerValidator : AbstractValidator<EditAnswerCommand>

    {
        #region Fields
        public EditAnswerValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.QuestionId)
                .NotEmpty().WithMessage("QuestionId Must not Be Empty")
                .NotNull().WithMessage("QuestionId Must not Be Null");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Must not Be Empty")
                .NotNull().WithMessage("Id Must not Be Null");
            RuleFor(x => x.Answer)
                .NotNull().WithMessage("Answer Must not Be Null");
            RuleFor(x => x.IsCorrect)
                .NotNull().WithMessage("IsCorrect Must not Be Null");

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
