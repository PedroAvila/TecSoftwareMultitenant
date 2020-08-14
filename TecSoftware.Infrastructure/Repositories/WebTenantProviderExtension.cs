using Microsoft.AspNetCore.Builder;

namespace TecSoftware.Infrastructure
{
    public static class WebTenantProviderExtension
    {
        public static IApplicationBuilder UseWebTenantProvider(this IApplicationBuilder app)
        {
            app.UseMiddleware<WebTenantProvider>();
            return app;
        }
    }
}
