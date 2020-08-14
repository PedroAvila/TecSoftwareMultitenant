using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoOrdenInventarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISdProductoOrdenInventario _productoOrdenInventario;


        public ProductoOrdenInventarioController(IMapper mapper, ISdProductoOrdenInventario productoOrdenInventario)
        {
            _mapper = mapper;
            _productoOrdenInventario = productoOrdenInventario;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SingleIncludes(int id)
        {

            var entity = await _productoOrdenInventario.SingleIncludes(x => x.ProductoOrdenInventarioId == id);
            var entityDto = _mapper.Map<ProductoOrdenInventarioDto>(entity);
            //var response = new ApiResponse<PostDto>(postDto);
            return Ok(entityDto);
        }
    }
}
