using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly ISdServidor _sdServidor;
        private readonly IMapper _mapper;

        public ServidorController(ISdServidor sdServidor, IMapper mapper)
        {
            _sdServidor = sdServidor;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServidorDto servidorDto)
        {
            var servidor = _mapper.Map<Servidor>(servidorDto);
            await _sdServidor.Create(servidor);
            servidorDto = _mapper.Map<ServidorDto>(servidor);
            //var response = new ApiResponseType
            return Ok(servidorDto);
        }
    }
}
