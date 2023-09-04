using Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Commands.Models
{
    public class DeleteExamCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteExamCommand(Guid id)
        {
            Id = id;

        }
    
    }
}
