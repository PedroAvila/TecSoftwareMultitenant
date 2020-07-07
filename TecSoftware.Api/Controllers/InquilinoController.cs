using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinoController : ControllerBase
    {
        private readonly ISdInquilino _sdInquilino;
        private readonly IService _service;
        private readonly IMapper _mapper;
        private readonly CatalogoInquilinoContext _context;
        private readonly ITenantProvider _tenantProvider;

        public InquilinoController(IService service, IMapper mapper,
            ITenantProvider tenantProvider, CatalogoInquilinoContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
            //_context.CreatePrueba();
            //_tenantProvider = tenantProvider;
            //_sdPrueba = sdPrueba;
        }

        [HttpPost("{nombre}")]
        public async Task<IActionResult> ConexionInquilino(string nombre)
        {

            await _service.ObtenerTenant(nombre);
            _context.CreatePrueba();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InquilinoDto inquilinoDto)
        {
            var inquilino = _mapper.Map<Inquilino>(inquilinoDto);
            await _sdInquilino.Create(inquilino);
            inquilinoDto = _mapper.Map<InquilinoDto>(inquilino);
            return Ok(inquilinoDto);
        }
    }
}
