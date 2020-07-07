using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ITenantProvider
    {
        InquilinoExtend GetTenant();
    }
}
