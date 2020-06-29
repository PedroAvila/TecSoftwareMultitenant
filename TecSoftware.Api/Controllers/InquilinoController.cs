using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinoController : ControllerBase
    {
        private readonly ISdInquilino _sdInquilino;
        private readonly IMapper _mapper;

        public InquilinoController(ISdInquilino sdInquilino, IMapper mapper)
        {
            _sdInquilino = sdInquilino;
            _mapper = mapper;
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
