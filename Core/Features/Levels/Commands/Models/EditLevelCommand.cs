﻿using Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Levels.Commands.Models
{
    public class EditLevelCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
    
}
