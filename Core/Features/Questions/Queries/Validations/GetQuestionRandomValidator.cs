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
    public class GetQuestionRandomValidator : AbstractValidator<GetQuestionRandom>

    {
        #region Fields
        public GetQuestionRandomValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.ExamId)
                .NotEmpty().WithMessage("ExamId Must not Be Empty")
                .NotNull().WithMessage("ExamId Must not Be Null");

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}

