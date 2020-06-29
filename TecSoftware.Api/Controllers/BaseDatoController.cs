using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDatoController : ControllerBase
    {
        private readonly ISdBaseDato _sdBaseDato;
        private readonly IMapper _mapper;

        public BaseDatoController(ISdBaseDato sdBaseDato, IMapper mapper)
        {
            _sdBaseDato = sdBaseDato;
            _mapper = mapper;
        }

        [HttpGet("{nameTenan}")]
        public async Task<IActionResult> GetAll(string nameTenan)
        {
            var baseDato = await _sdBaseDato.GetAll(nameTenan);
            //var baseDatoDto = _mapper.Map<BaseDatoDto>(baseDato);
            var list = baseDato.ToList();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseDatoDto baseDatoDto)
        {
            var baseDato = _mapper.Map<BaseDato>(baseDatoDto);
            await _sdBaseDato.Create(baseDato);
            baseDatoDto = _mapper.Map<BaseDatoDto>(baseDato);
            //var response = new ApiResponseType
            return Ok(baseDatoDto);
        }
    }
}
