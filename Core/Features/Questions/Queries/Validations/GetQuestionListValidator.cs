using Application.Features.Questions.Commands.Models;
using Application.Features.Questions.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.Validations
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
