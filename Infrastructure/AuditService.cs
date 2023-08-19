using Data.Audit.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AuditService : IAuditService
    {
        private readonly IHttpContextAccessor _httpContext;

        public AuditService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string UserName => _httpContext?.HttpContext?.User?.Identity?.Name ?? "Anonymous";
        public string UserType => _httpContext.HttpContext?.User?.FindFirstValue("userType") ?? string.Empty;
        public string UserId => _httpContext?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Anonymous";

    }

}
