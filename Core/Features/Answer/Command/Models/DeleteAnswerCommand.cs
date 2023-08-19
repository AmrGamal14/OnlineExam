using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Command.Models
{
    public class DeleteAnswerCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteAnswerCommand(Guid id)
        {
            Id = id;

        }
    }
}
