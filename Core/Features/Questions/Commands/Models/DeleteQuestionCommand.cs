using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Questions.Commands.Models
{
    public class DeleteQuestionCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteQuestionCommand(Guid id)
        {
            Id = id;

        }
    
    }
}
