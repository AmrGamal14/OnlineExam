using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Features.UserCQRS.Command.Models;
using Data.Entities.Identity;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfil
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, User>();

        }
    }
}
