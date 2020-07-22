
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.Core;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISdInquilino _sdInquilino;
        private readonly IMapper _mapper;

        public TokenController(IConfiguration configuration, IMapper mapper, ISdInquilino sdInquilino)
        {
            _configuration = configuration;

            _mapper = mapper;
            _sdInquilino = sdInquilino;
            //_tenantProvider = tenantProvider;
        }

        [HttpPost]
        public IActionResult Authentication(UserLoginDto user)
        {
            if (!string.IsNullOrEmpty(user.Tenant))
            {
                if (IsValidUser(Utilidades.Desifrar(user.Tenant)).Result)
                {
                    var token = GenerateToken(Utilidades.Desifrar(user.Tenant));
                    return Ok(new { token });
                }
            }
            return NotFound();
        }

        private async Task<bool> IsValidUser(string tenant)
        {
            //Autentificar en DB del negocio.
            bool exist = await _sdInquilino.Exist(x => x.Nombre == tenant);
            return exist;
        }

        private string GenerateToken(string tenant)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, tenant),
                //new Claim(ClaimTypes.Email, pass),
                //new Claim(ClaimTypes.Role, Utilidades.Desifrar(user.Tenant)),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void Obtenerconexion(string tenant)
        {

        }
    }
}
