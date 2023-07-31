using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Features.UserCQRS.Command.Models;
using Data.Entities.Identity;
using Data.Enums;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfil
    { public void AddUserMapping ()
        {
            CreateMap<AddUserCommand, User>();
            //CreateMap<AddUserCommand, RoleEnum>();
        }
    }
}
