using Core.Features.Levels.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Queries.Validations
{
    public class GetLevelValidator : AbstractValidator<GetLevelListBySubjectIdQuery>
    {
        public GetLevelValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }

        private void ApplyValidationsRules()
        {

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage("SubjectId Must not Be Empty")
                .NotNull().WithMessage("SubjectId Must not Be Null");
        }

        private void ApplyCustomValidationsRules()
        {

        }
    }
}
