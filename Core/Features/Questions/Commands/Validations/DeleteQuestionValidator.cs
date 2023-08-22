using Core.Features.Questions.Commands.Models;
using Core.Features.Subjects.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Commands.Validations
{
    public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionCommand>

    {
        #region Fields
        public DeleteQuestionValidator()
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
