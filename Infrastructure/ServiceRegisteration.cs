using Data.Entities.Helper;
using Data.Entities.Identity;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(
                option =>
                {
                    //Password setting
                    option.Password.RequireDigit=true;
                    option.Password.RequireLowercase=true;
                    option.Password.RequireNonAlphanumeric=true;
                    option.Password.RequireUppercase=true;
                    option.Password.RequiredLength=6;
                    option.Password.RequiredUniqueChars=1;
                    //Lockout Setting
                    option.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(5);
                    option.Lockout.MaxFailedAccessAttempts=5;
                    option.Lockout.AllowedForNewUsers=true;
                    //User Setting
                    option.User.RequireUniqueEmail = false;
                }).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();


            // JWT authentication
            var jwtSettings = new JwtSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata=false;
               x.SaveToken=true;
               x.TokenValidationParameters=new TokenValidationParameters
               {
                   ValidateIssuer = jwtSettings.ValidateIssuer,
                   ValidIssuers=new[] { jwtSettings.Issuer },
                   ValidateIssuerSigningKey=jwtSettings.ValidateIssureSigningKey,
                   IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                   ValidAudience=jwtSettings.Audience,
                   ValidateAudience=jwtSettings.ValidateAudience,
                   ValidateLifetime=jwtSettings.ValidateLifeTime,


               };
           });
            return services;
        }
    }
}
