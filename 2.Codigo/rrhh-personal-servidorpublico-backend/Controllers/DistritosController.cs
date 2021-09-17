using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personas.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.backend.Controllers
{
    [Route("v1/rrhh/personal/servidorpublico/distritos")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        private readonly IConfiguration config;

        public DistritosController(IConfiguration config)
        {
            this.config = config;
        }

        // GET: distritos?idDepartamento={idDepartamento}&idProvincia={idProvincia}
        [HttpGet("", Name = "GetDistritosByIdProvincia")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistritosByIdProvincia(int idDepartamento, int idProvincia)
        {
            IEnumerable<Distrito> response;
            IDistritoService distritoService;
            distritoService = new DistritoService(config.GetConnectionString("DefaultConnection"));
            response = await distritoService.GetDistritosByIdProvincia(idDepartamento, idProvincia);
            return Ok(new StatusResponse(response));
        }

        // GET: distritos/{idDistrito}
        [HttpGet("{idDistrito}", Name = "GetDistritoPorId")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistritoPorId(int idDistrito)
        {
            Distrito response;
            IDistritoService distritoService;
            distritoService = new DistritoService(config.GetConnectionString("DefaultConnection"));
            response = await distritoService.GetDistritoPorId(idDistrito);
            return Ok(new StatusResponse(response));
        }
    }
}