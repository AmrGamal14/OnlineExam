using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Features.UserCQRS.Query.Result;
using Data.Entities.Identity;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfil
    {
        public void GetListUser()
        {
            CreateMap<User, GetUserListResult>();
        }
    }
}
