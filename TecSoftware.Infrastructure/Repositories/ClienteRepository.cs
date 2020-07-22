using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ClienteRepository : BaseRepository<Cliente>, ICliente<Cliente>
    {
        public async Task<IEnumerable<UniversalExtend>> ListaClienteXCodigo(Criteria filter)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var resul = from c in context.Clientes
                            join t in context.TipoIdentificaciones on c.TipoIdentificacionId equals t.TipoIdentificacionId
                            where
                                t.Codigo == "04" & c.TipoIdentificacionId == 1 &&
                                (c.Numero == null || c.Numero.Contains(filter.Ruc))
                                ||
                                t.Codigo == "05" & c.TipoIdentificacionId == 2 &&
                                (c.Numero == null || c.Numero.Contains(filter.Cedula))
                                ||
                                t.Codigo == "06" & c.TipoIdentificacionId == 3 &&
                                (c.Numero == null || c.Numero.Contains(filter.Pasaporte))
                                || c.RazonSocial == null || c.RazonSocial.Contains(filter.RazonSocial)
                            select
                                new UniversalExtend()
                                {
                                    Id = c.ClienteId,
                                    Ruc = t.Codigo == "04" ? c.Numero : "",
                                    Cedula = t.Codigo == "05" ? c.Numero : "",
                                    Pasaporte = t.Codigo == "06" ? c.Numero : "",
                                    Descripcion = c.RazonSocial
                                };
                return await resul.ToListAsync();
            }
        }
    }
}
