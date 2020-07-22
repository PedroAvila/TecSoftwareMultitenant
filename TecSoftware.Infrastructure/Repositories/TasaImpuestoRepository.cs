using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class TasaImpuestoRepository : BaseRepository<TasaImpuesto>, ITasaImpuesto<TasaImpuesto>
    {
        private readonly List<TasaImpuesto> _tasaImpuestoItem = new List<TasaImpuesto>();

        public List<TasaImpuesto> DetalleItemTemp => _tasaImpuestoItem.ToList();


        public void Agregar(TasaImpuesto entity)
        {
            _tasaImpuestoItem.Add(entity);
        }

        public void CleanTasaImpuesto()
        {
            _tasaImpuestoItem.Clear();
        }


        //public TasaImpuesto ObtenerConceptoImpuestoObligadoContabilidad()
        //{
        //    using (var context = new BusinessContext())
        //    {
        //        var result = from ti in context.TasaImpuestos
        //            where ti.ImpuestoId == 1 && ti.Tasa > 0 && (int) ti.Estado == 1
        //            select ti.TasaImpuestoId
        //        return result;
        //    } 
        //}
    }
}
