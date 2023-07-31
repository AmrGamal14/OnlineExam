using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Service.Implementations;
using Service.Abstracts;

namespace Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services
            .AddTransient<IAuthenticationService, AuthenticationService>()
            .AddTransient<IAuthorizationService, AuthorizationService>();
            return services;
        }

    }
}