﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(UsuarioDto usuarioDto)
        {
            //Si es un usuario valido
            //if (IsValidUser(login))
            //{
            //    var token = GenerateToken();
            //    return Ok(new { token });
            //}
            //return NotFound();
            if (!string.IsNullOrEmpty(usuarioDto.User)
                && !string.IsNullOrEmpty(usuarioDto.Password)
                && !string.IsNullOrEmpty(usuarioDto.Tenant))
            {
                var token = GenerateToken(Utilidades.Desifrar(usuarioDto.User), Utilidades.Desifrar(usuarioDto.Password)
                    , Utilidades.Desifrar(usuarioDto.Tenant));
                return Ok(new { token });
            }
            return NotFound();
        }

        private bool IsValidUser(UserLogin login)
        {
            return true;
        }

        private string GenerateToken(string user, string pass, string tenant)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Email, pass),
                new Claim(ClaimTypes.Role, tenant),
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