using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdDetalleComprobantePago
    {
        Task Agregar(DetalleComprobantePagoExtend entity);
        void Clean();
        List<DetalleComprobantePagoExtend> MostrarComprobantePago();
        void Remove(int id);
        Task<DetalleComprobantePago> Single(Expression<Func<DetalleComprobantePago, bool>> predicate, List<Expression<Func<DetalleComprobantePago, object>>> includes);
        decimal SumaIva();
        decimal SumaSubTotal();
        decimal SumaSubTotalCero();
        decimal SumaTotal();
    }
}