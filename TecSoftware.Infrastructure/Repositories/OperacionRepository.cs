using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class OperacionRepository : BaseRepository<Operacion>, IOperacion<Operacion>
    {
        /// <summary>
        /// Verifica si la entidad tiene registros dados de alta.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> VerificarRegistro()
        {
            using (var context = new BusinessContext())
            {
                var query = await (from o in context.Operaciones select o).AnyAsync();
                return query;
            }
        }

        /// <summary>
        /// Validación para comprobar si es el mismo punto de emisión cuando se inicia una operación.
        /// </summary>
        /// <param name="puntoEmision">Punto de emisión</param>
        /// <returns></returns>
        public async Task<bool> ValidarOperacion(int puntoEmision)
        {
            using (var context = new BusinessContext())
            {
                var query = await (from o in context.Operaciones
                                   where o.OperacionStatus == OperacionCaja.Cerrar
                                   && o.PuntoEmisionId == puntoEmision
                                   select o).AnyAsync();
                return query;
            }
        }


    }
}
