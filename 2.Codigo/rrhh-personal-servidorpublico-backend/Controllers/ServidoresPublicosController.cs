using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.imp;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.backend.Controllers
{
    [Route("v1/rrhh/personal/servidorpublico/servidorespublicos")]
    [ApiController]
    public class ServidoresPublicosController : ControllerBase
    {
        private readonly IConfiguration config;

        public ServidoresPublicosController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet("{idServidorPublico}", Name = "GetServidorPublicoPorId")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServidorPublicoPorId([FromRoute] long idServidorPublico, [FromQuery] string e)
        {
            bool todo = false;
            bool formacionAcademica = false;
            if (!String.IsNullOrEmpty(e))
            {
                List<string> lista = e.Trim().ToLower().Split(',').ToList<string>();
                if (lista.Contains("todo"))
                    todo = true;
                if (lista.Contains("formacionacademica"))
                    formacionAcademica = true;
            }

            IServidorPublicoService servidorPublico = new ServidorPublicoService(config.GetConnectionString("DefaultConnection"));
            ServidorPublicoReplica response = await servidorPublico.GetServidorPublicoReplicaPorId(idServidorPublico, todo, formacionAcademica);
            return Ok(new StatusResponse(response));
        }

        [HttpGet("porcodigo/{codigoServidorPublico}", Name = "GetServidorPublicoByCodigo")]
        [Produces("application/json", Type = typeof(StatusResponse))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServidorPublicoByCodigo([FromRoute] long codigoServidorPublico, [FromQuery] string e)
        {
            bool todo = false;
            bool formacionAcademica = false;

            if (!String.IsNullOrEmpty(e))
            {
                List<string> lista = e.Trim().ToLower().Split(',').ToList<string>();
                if (lista.Contains("todo"))
                    todo = true;
                if (lista.Contains("formacionacademica"))
                    formacionAcademica = true;
            }

            IServidorPublicoService servidorPublico = new ServidorPublicoService(config.GetConnectionString("DefaultConnection"));
            ServidorPublicoReplica response = await servidorPublico.GetServidorPublicoReplicaPorCodigo(codigoServidorPublico, todo, formacionAcademica);
            return Ok(new StatusResponse(response));
        }
    }
}
