using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.backend.Controllers
{
    [Route("v1/rrhh/personal/servidorpublico/paises")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IConfiguration config;

        public PaisesController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaises()
        {
            IPaisService paisService = new PaisService(config.GetConnectionString("DefaultConnection"));
            IEnumerable<Pais> response = await paisService.GetPaises();
            return Ok(new StatusResponse(response));
        }

        [HttpGet("{idPais}", Name = "GetPaisPorId")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaisPorId(int idPais)
        {
            IPaisService paisService = new PaisService(config.GetConnectionString("DefaultConnection"));
            Pais response = await paisService.GetPaisPorId(idPais);
            return Ok(new StatusResponse(response));
        }

        [HttpGet("porcodigo/{codigoPais}", Name = "GetPaisPorCodigo")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaisPorCodigo(string codigoPais)
        {
            IPaisService paisService = new PaisService(config.GetConnectionString("DefaultConnection"));
            Pais response = await paisService.GetPaisPorCodigo(codigoPais);
            return Ok(new StatusResponse(response));
        }
    }
}