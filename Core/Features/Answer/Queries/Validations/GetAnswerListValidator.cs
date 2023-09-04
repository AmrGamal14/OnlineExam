using Application.Features.Answer.Command.Models;
using Application.Features.Answer.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Answer.Queries.Validations
{
    public class GetAnswerListValidator : AbstractValidator<GetAnswerListQuery>

    {
        #region Fields
        public GetAnswerListValidator()
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


        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
