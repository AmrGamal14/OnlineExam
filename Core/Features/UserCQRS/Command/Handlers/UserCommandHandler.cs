using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bases;
using Application.Features.UserCQRS.Command.Models;
using Data.Entities.Identity;
using Data.Enums;
using Application.Resources;
using Microsoft.Extensions.Localization;

namespace Application.Features.UserCQRS.Command.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                                     , IRequestHandler<UpdateUserCommand, Response<string>>
                                                     , IRequestHandler<DeleteUserCommand, Response<string>>
                                                     , IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors 
        public UserCommandHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;

        }
        #endregion

        #region Handle Functions
        public async  Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //if Email is Exist
            var useremail = await _userManager.FindByEmailAsync(request.Email);
            //Email is Exist 
            if (useremail != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailExist]);
            //if UserName is Exist 
            var username = await _userManager.FindByNameAsync(request.UserName);
            //UserName is Exist 
            if (username != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserExist]);
            //Mapping 
            var identityuser = _mapper.Map<User>(request);
            //Create
            var createruslt = await _userManager.CreateAsync(identityuser,request.Password); 
            //Field 
            if (!createruslt.Succeeded) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddUser]);
            if (request.Role == RoleEnum.Teacher)
            {
                await _userManager.AddToRoleAsync(identityuser, "Teacher");
            }
            else if(request.Role == RoleEnum.User)
            {
                await _userManager.AddToRoleAsync(identityuser, "User");
            }
       
            //Create 
            //Success
            return Created("Successfully");
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByNameAsync(request.UserName);
            if (oldUser == null) return NotFound<string>();
            var newUser = _mapper.Map(request, oldUser);
            var result = await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return BadRequest<string>("Edit Not Successfully");
            return success("Edit Successfully");



        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<string>();
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest<string>("Delete Not Successfully");
            return success("Delete Successfully");

        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<string>("NotFound");
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return BadRequest<string>("Not Successfully");
            return success("Successfully"); 
        }

        #endregion

    }
}
