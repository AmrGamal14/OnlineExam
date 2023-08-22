using Core.Bases;
using Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Commands.Models
{
    public class EditQuestionCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public SkillLevel SkillName { get; set; }

    }
}
