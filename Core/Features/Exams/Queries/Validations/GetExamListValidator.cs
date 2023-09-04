using Application.Features.Exams.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Queries.Validations
{
    public class GetExamListValidator : AbstractValidator<GetExamListQuery>

    {
        #region Fields
        public GetExamListValidator()
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
