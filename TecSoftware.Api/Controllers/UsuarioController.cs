using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ISdUsuario _sdUsuario;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly ITenantProvider _tenantProvider;
        public UsuarioController(ISdUsuario sdUsuario, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _sdUsuario = sdUsuario;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_tenantProvider = tenantProvider;

            //var name = _tenantProvider.GetName();
        }

        [HttpGet("[action]")]
        public async Task<bool> Autentificar([FromQuery] string user, [FromQuery] string password)
        {//UsuarioDto usuarioDto
            var usuarioDto = new UsuarioDto()
            {
                User = user,
                Password = password
            };

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var exist = await _sdUsuario.Autentificar(usuario);
            if (exist)
                return exist;
            return exist;
        }
    }
}
