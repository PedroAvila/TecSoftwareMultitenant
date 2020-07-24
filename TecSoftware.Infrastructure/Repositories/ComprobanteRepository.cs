using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class ComprobanteRepository : BaseRepository<Comprobante>, IComprobante<Comprobante>
    {
        public async Task AsignarIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            using (var context = new BusinessContext())
            {
                //await Task.Run(() =>
                //{
                //    context.Entry(comprobante).State = EntityState.Unchanged;
                //});

                context.Entry(comprobante).State = EntityState.Unchanged;


                if (comprobante.TipoIdentificaciones == null)
                    comprobante.TipoIdentificaciones = new List<TipoIdentificacion>();
                await Task.Run(() =>
                {//Recorremos cada Modelo que se quiera asociar
                    identificaciones.ForEach(async x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        comprobante.TipoIdentificaciones.Add(x);
                        await context.SaveChangesAsync();
                    });
                });
            }
        }

        public async Task RemoveIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            //validamos que haya algo que remover
            if (identificaciones == null || identificaciones.Count == 0)
                return;

            using (var context = new BusinessContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Comprobante comprobanteSel = await context.Set<Comprobante>().Include("TipoIdentificaciones")
                    .FirstOrDefaultAsync(x => x.ComprobanteId == comprobante.ComprobanteId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (comprobante.TipoIdentificaciones == null || comprobante.TipoIdentificaciones.Count == 0)
                    return;

                identificaciones.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (comprobanteSel != null)
                    {
                        TipoIdentificacion modeloRemove =
                            comprobanteSel.TipoIdentificaciones.First(e => e.TipoIdentificacionId == x.TipoIdentificacionId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        comprobanteSel.TipoIdentificaciones.Remove(modeloRemove);
                    }
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> ComprobantePagos()
        {
            using (var context = new BusinessContext())
            {
                var list = from c in context.Comprobantes
                           where c.Codigo != "06"
                           select new UniversalExtend()
                           {
                               Id = c.ComprobanteId,
                               Descripcion = c.Nombre
                           };
                return await list.ToListAsync();
            }
        }
    }
}
