using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class PaisService : ServiceBase, IPaisService
    {
        public PaisService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        public async Task<IEnumerable<Pais>> GetPaises()
        {
            IEnumerable<Pais> response;
            try
            {
                IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
                response = await paisDAO.GetPaises();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Pais> GetPaisPorCodigo(string codigoPais)
        {
            Pais response;
            try
            {
                IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
                response = await paisDAO.GetPaisPorCodigo(codigoPais);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<Pais> GetPaisPorId(int idPais)
        {
            Pais response;
            try
            {
                IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
                response = await paisDAO.GetPaisPorId(idPais);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<int> CrearReplica(PaisReplica request)
        {
            IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
            Pais pais = new Pais
            {
                codigoPais = request.codigoPais,
                descripcionPais = request.descripcionPais,
                abreviaturaPais = request.abreviaturaPais,
                activo = request.activo,
                fechaCreacion = DateTime.Now,
                usuarioCreacion = request.usuarioCreacion,
                ipCreacion = request.ipCreacion
            };

            pais.idPais = await paisDAO.GetIdPaisPorCodigo(request.codigoPais);
            if (pais.idPais <= 0)
                return await paisDAO.CrearPais(pais);

            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await paisDAO.ActualizarPais(pais);
        }

        public async Task<int> ActualizarReplica(PaisReplica request)
        {
            IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
            Pais pais = new Pais
            {
                codigoPais = request.codigoPais,
                descripcionPais = request.descripcionPais,
                abreviaturaPais = request.abreviaturaPais,
                activo = request.activo,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion
            };

            pais.idPais = await paisDAO.GetIdPaisPorCodigo(request.codigoPais);
            if (pais.idPais <= 0)
                return await paisDAO.CrearPais(pais);
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await paisDAO.ActualizarPais(pais);
        }

        public async Task<int> EliminarReplica(PaisReplica request)
        {
            IPaisDAO paisDAO = new PaisDAO(txtConnectionString);
            Pais pais = new Pais
            {
                codigoPais = request.codigoPais,
                descripcionPais = request.descripcionPais,
                abreviaturaPais = request.abreviaturaPais,
                activo = false,
                fechaModificacion = DateTime.Now,
                usuarioModificacion = request.usuarioModificacion,
                ipModificacion = request.ipModificacion
            };

            pais.idPais = await paisDAO.GetIdPaisPorCodigo(request.codigoPais);
            if (pais.idPais <= 0)
                return 1;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await paisDAO.ActualizarPais(pais);
        }
    }
}