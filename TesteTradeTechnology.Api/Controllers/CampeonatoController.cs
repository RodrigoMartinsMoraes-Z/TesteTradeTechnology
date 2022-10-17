using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TesteTradeTechnology.CrossCutting.Interfaces.Services;
using TesteTradeTechnology.Models.Campeonatos;

namespace TesteTradeTechnology.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoService _campeonatoService;
        private readonly IMapper _mapper;

        public CampeonatoController(ICampeonatoService campeonatoService, IMapper mapper)
        {
            _campeonatoService = campeonatoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GerarResultados")]
        public async Task<ActionResult> GerarResultados()
        {
            var resultado = await _campeonatoService.SimularCampeonato();

            return Ok(_mapper.Map<CampeonatoModel>(resultado));
        }
    }
}
