using Application.Features.Questions.Queries.Models;
using Application.Features.StudentHistory.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Queries.Validations
{
    public class GetExamHistoryValidator : AbstractValidator<GetExamHistory>

    {
        #region Fields
        public GetExamHistoryValidator()
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
