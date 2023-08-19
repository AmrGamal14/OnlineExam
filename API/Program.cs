using Core;
using Core.Extensions;
using Core.MiddleWare;
using Data.Entities.Identity;
using Data.Entities.Models;
using Infrastructure;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Seeder;
using Infrastructure.SeedIntiliazer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



#region Connection To SQL Server

builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});
#endregion

#region Dependency injections
builder.Services.AddinfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies()
                .AddServiceRegisteration(builder.Configuration);
#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => { opt.ResourcesPath=""; });
builder.Services.Configure<RequestLocalizationOptions>(Options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG")
    };
    Options.DefaultRequestCulture=new RequestCulture("en-US");
    Options.SupportedCultures=supportedCultures;
    Options.SupportedUICultures=supportedCultures;

});
#endregion

var app = builder.Build();
UseAuditExtension.Initialize(app.Services.GetRequiredService<IServiceScopeFactory>());

#region DataSeed
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var skillRepository = scope.ServiceProvider.GetRequiredService<ISkillRepository>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
    await SkillSeeder.SeedAsync(skillRepository);

}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseHttpsRedirection();


app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
