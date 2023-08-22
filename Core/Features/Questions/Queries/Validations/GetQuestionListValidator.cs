using Core.Features.Questions.Commands.Models;
using Core.Features.Questions.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Queries.Validations
{
    public class GetQuestionListValidator : AbstractValidator<GetQuestionListQuery>

    {
        #region Fields
        public GetQuestionListValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
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
