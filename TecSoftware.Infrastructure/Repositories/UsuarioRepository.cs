using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class UsuarioRepository : BaseBusinessRepository<Usuario>, IUsuario<Usuario>
    {
        public async Task<bool> Autentificar(Usuario entity)
        {
            using (var context = new BusinessContext())
            {
                var count = await (from u in context.Usuarios
                    .Where(x => x.User == entity.User && x.Password == entity.Password)
                                   select u).CountAsync();

                return count > 0;
            }
        }

        public async Task UpdateUser(Usuario entity)
        {
            using (var context = new BusinessContext())
            {
                var query = await (from u in context.Usuarios
                                   where u.UsuarioId == entity.UsuarioId
                                   select u).FirstOrDefaultAsync();
                query.Nombre = entity.Nombre;
                query.RolId = entity.RolId;
                query.User = entity.User;
                query.Foto = entity.Foto;
                query.Estado = entity.Estado;
                context.SaveChanges();
            }
        }
        public async Task UpdatePassword(Usuario entity)
        {
            using (var context = new BusinessContext())
            {
                var query = await (from u in context.Usuarios
                                   where u.UsuarioId == entity.UsuarioId
                                   select u).FirstOrDefaultAsync();
                query.User = entity.User;
                query.Password = entity.Password;
                query.Estado = entity.Estado;
                await context.SaveChangesAsync();
            }
        }
    }
}
