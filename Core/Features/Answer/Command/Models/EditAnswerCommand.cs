using Application.Bases;
using MediatR;

namespace Application.Features.Answer.Command.Models
{
    public class EditAnswerCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}
