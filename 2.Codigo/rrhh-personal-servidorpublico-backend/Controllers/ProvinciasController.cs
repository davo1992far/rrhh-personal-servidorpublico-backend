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
    [Route("v1/rrhh/personal/servidorpublico/provincias")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IConfiguration config;

        public ProvinciasController(IConfiguration config)
        {
            this.config = config;
        }

        // GET: provincias?idDepartamento={idDepartamento}
        [HttpGet("", Name = "GetProvinciasByIdDepartamento")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            IEnumerable<Provincia> response;
            IProvinciaService provinciaService;
            provinciaService = new ProvinciaService(config.GetConnectionString("DefaultConnection"));
            response = await provinciaService.GetProvinciasByIdDepartamento(idDepartamento);
            return Ok(new StatusResponse(response));
        }

        // GET: provincias/{idProvincia}
        [HttpGet("{idProvincia}", Name = "GetProvinciaPorId")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProvinciaPorId(int idProvincia)
        {
            Provincia response;
            IProvinciaService provinciaService;
            provinciaService = new ProvinciaService(config.GetConnectionString("DefaultConnection"));
            response = await provinciaService.GetProvinciaPorId(idProvincia);
            return Ok(new StatusResponse(response));
        }
    }
}