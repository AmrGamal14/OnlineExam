using Infrastructure.Abstracts;
using Infrastructure.InfrastructureBases;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ModuleinfrastructureDependencies
    {
        public static IServiceCollection AddinfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>()
                .AddTransient(typeof(IGenericeRepositoryAsync<>), typeof(GenericRepositoryAsync<>)); 

            return services;
        }
    }
}