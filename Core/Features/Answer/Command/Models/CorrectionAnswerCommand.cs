using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Command.Models
{
    public class CorrectionAnswerCommand : IRequest<Response<string>>
    {
        public Guid ExamId { get; set; }
        public List<CorrectList>correctLists { get; set; }
      
    }
    public class CorrectList
    {
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
