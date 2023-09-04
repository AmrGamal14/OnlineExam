﻿using Application.Features.Answer.Command.Models;
using FluentValidation;

namespace Application.Features.Answer.Command.Validations
{
    public class AddAnswerValidator : AbstractValidator<AddAnswerCommand>

    {
        #region Fields
        public AddAnswerValidator()
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
