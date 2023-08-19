using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Commands.Models
{
    public class DeleteLevelCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteLevelCommand(Guid id)
        {
            Id = id;

        }
    
    }
}
