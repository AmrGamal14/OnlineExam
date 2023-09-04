using Application.Features.Exams.Commands.Models;
using Application.Features.Exams.Queries.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Exams.Queries.Validations
{
    public class GetExamByIdValidator : AbstractValidator<GetExamByIdQuery>

    {
        #region Fields
        public GetExamByIdValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Must not Be Empty")
                .NotNull().WithMessage("Id Must not Be Null");
           

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
    
    
}
