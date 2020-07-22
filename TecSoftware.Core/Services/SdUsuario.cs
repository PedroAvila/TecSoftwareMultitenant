using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdUsuario : ISdUsuario
    {
        public UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public async Task<bool> Autentificar(Usuario entity)
        {
            return await _usuarioRepository.Autentificar(entity);
        }

        public async Task UpdateUser(Usuario entity)
        {
            await _usuarioRepository.UpdateUser(entity);
        }
    }
}
