using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TesteTradeTechnology.CrossCutting.Interfaces.Services;

namespace TesteTradeTechnology.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        [HttpGet]
        public ActionResult GerarResultados()
        {
            var resultado = _campeonatoService.SimularCampeonato();

            return Ok(resultado);
        }
    }
}
