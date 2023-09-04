using Application.Bases;
using Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Commands.Models
{
    public class EditQuestionCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SkillLevel SkillName { get; set; }
        public string Questions { get; set; }
        public List<answer> Ans { get; set; }
    }
    public class answer
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
