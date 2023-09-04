//using Data.Entities.Identity;
//using Microsoft.AspNetCore.Identity;
//using Service.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service.Implementations
//{
//    public class AuthorizationService : IAuthorizationService
//    {
//        private readonly RoleManager<Role> _roleManager;

//        public AuthorizationService(RoleManager<Role> roleManager)
//        {
//            _roleManager=roleManager;
//        }
//        public async Task<string> AddRoleAsync(string roleName)
//        {
//            var identityrole = new Role();
//            identityrole.Name = roleName;
//            var result = await _roleManager.CreateAsync(identityrole);
//            if (result.Succeeded)
//                return "Success";
//            return "Failed";

//        }

//        public async Task<bool> IsRoleExist(string roleName)
//        {
//            return await _roleManager.RoleExistsAsync(roleName);

//        }
//    }
//}
