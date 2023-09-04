using Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Commands.Models
{
    public class AddExamCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public int Duration { get; set; }
        public Guid LevelId { get; set; }
    }
}
