using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Command.Models
{
    public class AddAnswerCommand : IRequest<Response<string>>
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }

    }
    
    
    
}
