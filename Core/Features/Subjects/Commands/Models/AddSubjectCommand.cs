using Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects.Commands.Models
{
    public class AddSubjectCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
