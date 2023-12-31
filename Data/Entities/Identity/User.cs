﻿using Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            UserRefreshTokens=new HashSet<UserRefreshToken>();
        }

        public string FullName { get; set; }
        public string? Adderss { get; set; }
        public string? Country { get; set; }


        [InverseProperty(nameof(UserRefreshToken.user))]
        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
        public HashSet<StudentExam> StudentExams { get; set; }
    }
}

