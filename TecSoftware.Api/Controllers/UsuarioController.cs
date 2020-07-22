using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ISdUsuario _sdUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(ISdUsuario sdUsuario, IMapper mapper)
        {
            _sdUsuario = sdUsuario;
            _mapper = mapper;
        }

        [HttpPost] //string user, string password
        public async Task<bool> Autentificar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var exist = await _sdUsuario.Autentificar(usuario);
            if (exist)
                return exist;
            return exist;
        }


    }
}
