using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ProveedorRepository : BaseInquilinoRepository<Proveedor>, IProveedor<Proveedor>
    {
        private readonly List<Proveedor> _proveedorItem = new List<Proveedor>();

        public List<Proveedor> DetalleItemTemp => _proveedorItem.ToList();


        public void Agregar(Proveedor entity)
        {
            _proveedorItem.Add(entity);
        }

        public void CleanProveedor()
        {
            _proveedorItem.Clear();
        }
    }
}
