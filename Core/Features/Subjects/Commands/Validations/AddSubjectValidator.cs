using Core.Features.Authentication.Command.Models;
using Core.Features.Subjects.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Commands.Validations
{
    public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>

    {
        #region Fields
        public AddSubjectValidator()
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

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}

    

