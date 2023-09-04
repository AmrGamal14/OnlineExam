using Data.Audit.Interfaces;
using Infrastructure.InfrastructureBases;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class UseAuditExtension
    {
        private static IServiceScopeFactory _serviceProvider;

        public static void Initialize(IServiceScopeFactory serviceScope)
        {
            _serviceProvider = serviceScope;
        }

        public static void UpdateEntityAudit<T>(this T entity)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var auditService = scope.ServiceProvider.GetService<IAuditService>();
                if (entity is not IUpdateAudit audit) return;
                audit.UpdatedBy = auditService.UserName;
                audit.UpdatedDate = DateTime.UtcNow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AddEntityAudit<T>(this T entity)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var auditService = scope.ServiceProvider.GetService<IAuditService>();
                if (entity is not ICreateAudit audit) return;
                audit.CreatedBy = auditService.UserId;
                audit.CreatedDate = DateTime.UtcNow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
