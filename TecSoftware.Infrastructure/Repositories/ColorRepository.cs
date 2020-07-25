using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ColorRepository : BaseInquilinoRepository<Colour>, IColor<Colour>
    {
        private readonly List<Colour> _colorItem = new List<Colour>();

        public List<Colour> DetalleItemTemp => _colorItem.ToList();


        public void Agregar(Colour entity)
        {
            _colorItem.Add(entity);
        }

        public void CleanColor()
        {
            _colorItem.Clear();
        }
    }
}
