using Application.Features.Questions.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Commands.Validations
{
    public class EditQuestionValidator : AbstractValidator<EditQuestionCommand>

    {
        #region Fields
        public EditQuestionValidator()
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
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description Must not Be Null");
            RuleFor(x => x.Questions)
                .NotNull().WithMessage("Questions Must not Be Null");
            RuleFor(x => x.SkillName)
                .NotNull().WithMessage("SkillName Must not Be Null");
           
        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
