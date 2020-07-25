using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class DetalleComprobantePagoRepository : BaseInquilinoRepository<DetalleComprobantePago>, IDetalleComprobantePago<DetalleComprobantePago>
    {
        private readonly List<DetalleComprobantePagoExtend> _comprobanteItem = new List<DetalleComprobantePagoExtend>();
        public List<DetalleComprobantePagoExtend> DetalleItemTemp => _comprobanteItem.ToList(); //IDetalleComprobantePago<DetalleComprobantePago>

        public async Task Agregar(DetalleComprobantePagoExtend entity)
        {
            await Task.Run(() => { _comprobanteItem.Add(entity); });
        }

        public decimal SumaSubTotal()
        {
            return _comprobanteItem.Sum(x => x.SubTotalIva);
        }

        public decimal SumaSubTotalCero()
        {
            return _comprobanteItem.Sum(x => x.SubTotalCero);
        }

        public decimal SumaIva()
        {
            return _comprobanteItem.Sum(x => x.ValorIva);
        }

        public decimal SumaTotal()
        {
            return _comprobanteItem.Sum(x => x.SubTotalIva + x.SubTotalCero + x.ValorIce + x.ValorIva);
        }

        public void Quitar(int indice)
        {
            if (_comprobanteItem.Count > 0)
                _comprobanteItem.RemoveAt(indice);
        }

        public void Remove(int id)
        {
            _comprobanteItem.RemoveAt(id);
        }

        public void Clean()
        {
            _comprobanteItem.Clear();
        }
    }
}
