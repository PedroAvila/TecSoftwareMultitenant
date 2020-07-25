using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class OperacionMovimientoRepository : BaseInquilinoRepository<OperacionMovimiento>, IOperacionMovimiento<OperacionMovimiento>
    {
        public async Task Registrar(OperacionMovimiento entity) //IOperacionMovimiento<OperacionMovimiento>
        {
            using (var context = new BusinessContext())
            {
                //Operacion Movimiento
                context.Entry(entity).State = EntityState.Added;
                //Producto Operacion Movimiento
                foreach (var pom in entity.ProductoOperacionMovimientos)
                {
                    context.Entry(pom).State = EntityState.Added;
                }
                //Registro Inventario
                foreach (var ri in entity.RegistroInventarios)
                {
                    context.Entry(ri).State = EntityState.Added;
                    //ProductoRegistroInventario
                    foreach (var pri in ri.ProductoRegistroInventarios)
                    {
                        context.Entry(pri).State = EntityState.Added;
                    }
                }
                await context.SaveChangesAsync();
            }

        }
    }
}
