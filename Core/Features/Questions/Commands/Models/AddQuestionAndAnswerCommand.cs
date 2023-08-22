using Core.Bases;
using Data.Entities.Models;
using Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Commands.Models
{
    public class AddQuestionAndAnswerCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public SkillLevel SkillName { get; set; }
        public Guid LevelId { get; set; }
        public List<AnswersList> AnswersList { get; set; }
     
    }
    public class AnswersList
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
