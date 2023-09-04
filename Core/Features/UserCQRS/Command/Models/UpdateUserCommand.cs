﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bases;

namespace Application.Features.UserCQRS.Command.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Adderss { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
