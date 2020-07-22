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
    public class InquilinoController : ControllerBase
    {
        private readonly ISdInquilino _sdInquilino;
        private readonly IMapper _mapper;

        public InquilinoController(IMapper mapper, ISdInquilino sdInquilino)
        {

            _mapper = mapper;
            _sdInquilino = sdInquilino;
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
