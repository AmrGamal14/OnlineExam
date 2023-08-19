using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteSubjectCommand(Guid id)
        {
            Id = id;

        }
    }
}
