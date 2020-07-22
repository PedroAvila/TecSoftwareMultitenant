using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TecSoftware.Core;

namespace TecSoftware.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;
        private IHttpContextAccessor _contextAccessor;
        public ServiceController(IService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> ConexionInquilino()
        {
            var nameClaim = _contextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;
            var tenant = await _service.ObtenerTenant(nameClaim);
            return Ok(nameClaim);
        }
    }
}
