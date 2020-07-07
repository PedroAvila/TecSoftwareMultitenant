using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        string con = string.Empty;

        public BaseDatoController(ISdBaseDato sdBaseDato, IMapper mapper)
        {
            _sdBaseDato = sdBaseDato;
            _mapper = mapper;
        }

        [HttpGet("{nameTenan}")]
        public async Task<IActionResult> Single(string nameTenan)
        {
            var baseDato = await _sdBaseDato.Single(x => x.Nombre == nameTenan,
                new List<Expression<Func<BaseDato, object>>>() { x => x.Servidor });

            if (baseDato != null)
            {
                con =
                $"Server={baseDato.Servidor.Nombre},1433;Database={baseDato.Nombre};" +
                "User ID=xxxxxxx;Password=xxxxxx;Trusted_Connection=False;" +
                "Encrypt=True;MultipleActiveResultSets=True;";
            }

            var cnn = HttpContext.Connection;


            return Ok(con);
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
