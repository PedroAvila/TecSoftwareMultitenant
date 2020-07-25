using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class TallaRepository : BaseBusinessRepository<Talla>, ITalla<Talla>
    {
        private readonly List<Talla> _tallaItem = new List<Talla>();

        public List<Talla> DetalleItemTemp => _tallaItem.ToList();


        public void Agregar(Talla entity)
        {
            _tallaItem.Add(entity);
        }

        public void CleanTalla()
        {
            _tallaItem.Clear();
        }
    }
}
