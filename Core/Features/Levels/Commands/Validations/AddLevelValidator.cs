using Application.Features.Levels.Commands.Models;
using Application.Features.Subjects.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Levels.Commands.Validations
{
    public class AddLevelValidator : AbstractValidator<AddLevelCommand>

    {
        #region Fields
        public AddLevelValidator()
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
            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage("SubjectId Must not Be Empty")
                .NotNull().WithMessage("SubjectId Must not Be Null");

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
