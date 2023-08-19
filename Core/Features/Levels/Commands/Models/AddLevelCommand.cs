using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Levels.Commands.Models
{
    public class AddLevelCommand : IRequest<Response<string>>
    {
        public Guid SubjectId { get; set; }

        public string Name { get; set; }
    }
    
    
}
