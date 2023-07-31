using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Bases;

namespace Core.Features.UserCQRS.Command.Models
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
