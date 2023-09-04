using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bases;

namespace Application.Features.UserCQRS.Command.Models
{
    public class DeleteUserCommand :IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id=id;  
        }
    }
}
