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
    public class AddQuestionValidator : AbstractValidator<AddQuestionAndAnswerCommand>

    {private int x =0;
        #region Fields
        public AddQuestionValidator()
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
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Description Must not Be Null");
            RuleFor(x => x.Questions)
                .NotNull().WithMessage("Questions Must not Be Null");
           
            RuleFor(x => x.SkillName)
                .NotNull().WithMessage("SkillName Must not Be Null");
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
