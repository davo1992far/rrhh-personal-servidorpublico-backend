using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.backend.Controllers
{
    [Route("v1/rrhh/personal/servidorpublico/departamentos")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IConfiguration config;

        public DepartamentosController(IConfiguration config)
        {
            this.config = config;
        }

        // GET: departamento
        [HttpGet("", Name = "GetDepartamentos")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartamentos()
        {
            IDepartamentoService departamentoService = new DepartamentoService(config.GetConnectionString("DefaultConnection"));
            IEnumerable<Departamento> response = await departamentoService.GetDepartamentos();
            return Ok(new StatusResponse(response, new List<string> {Constante.DEPARTAMENTO_SUCCESS}));
        }

        // GET: departamento/{idDepartamento}
        [HttpGet("{idDepartamento}", Name = "GetDepartamentoPorId")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartamentoPorId(int idDepartamento)
        {
            Departamento response;
            IDepartamentoService departamentoService;
            departamentoService = new DepartamentoService(config.GetConnectionString("DefaultConnection"));
            response = await departamentoService.GetDepartamentoPorId(idDepartamento);
            return Ok(new StatusResponse(response, new List<string> { Constante.DEPARTAMENTO_SUCCESS }));
        }
    }
}
