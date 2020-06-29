using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class CachingTenantResolver : MemoryCacheTenantResolver<Inquilino>
    {
        private readonly CatalogoInquilinoContext _context;
        public CachingTenantResolver(
            CatalogoInquilinoContext context, IMemoryCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            _context = context;
        }

        //Resolver se ejecuta en errores de caché
        protected override async Task<TenantContext<Inquilino>> ResolveAsync(HttpContext context)
        {
            var subdomain = context.Request.Host.Host.ToLower();
            var tenant = await _context.Inquilinos
                .FirstOrDefaultAsync(i => i.Dominio == subdomain);
            if (tenant == null) return null;
            return new TenantContext<Inquilino>(tenant);
        }

        protected override MemoryCacheEntryOptions CreateCacheEntryOptions()
            => new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(2));

        protected override string GetContextIdentifier(HttpContext context)
            => context.Request.Host.Host.ToLower();

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<Inquilino> context)
            => new string[] { context.Tenant.Dominio };
    }
}
