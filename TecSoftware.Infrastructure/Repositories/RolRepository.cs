using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class RolRepository : BaseBusinessRepository<Rol>, IRol<Rol>
    {
        public async Task AsignarFunciones(Rol rol, List<Funcion> funciones) // IRol<Rol>
        {
            using (var context = new BusinessContext())
            {
                context.Entry(rol).State = EntityState.Unchanged;

                if (rol.Funciones == null)
                    rol.Funciones = new List<Funcion>();

                await Task.Run(() =>
                {
                    //Recorremos cada Modelo que se quiera asociar
                    funciones.ForEach(x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        rol.Funciones.Add(x);
                        context.SaveChanges();
                    });
                });
            }
        }

        public async Task RemoveFunciones(Rol rol, List<Funcion> funciones)
        {
            //validamos que haya algo que remover
            if (funciones == null || funciones.Count == 0)
                return;

            using (var context = new BusinessContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Rol rolSel = await context.Set<Rol>().Include("Funciones")
                    .FirstOrDefaultAsync(x => x.RolId == rol.RolId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (rol.Funciones == null || rol.Funciones.Count == 0)
                    return;

                funciones.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (rolSel != null)
                    {
                        Funcion modeloRemove =
                            rolSel.Funciones.First(e => e.FuncionId == x.FuncionId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        rolSel.Funciones.Remove(modeloRemove);
                    }
                });

                await context.SaveChangesAsync();
            }
        }

    }
}
