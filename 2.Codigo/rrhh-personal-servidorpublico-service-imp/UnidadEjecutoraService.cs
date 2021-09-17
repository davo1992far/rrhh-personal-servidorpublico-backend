using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class UnidadEjecutoraService : ServiceBase, IUnidadEjecutoraService
    {
        public UnidadEjecutoraService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> Crear(UnidadEjecutoraReplica request)
        {
            try
            {
                IUnidadEjecutoraDAO unidadEjecutoraDAO = new UnidadEjecutoraDAO(txtConnectionString);

                if (request.idPliego <= 0 || request.secuenciaUnidadEjecutora <= 0)
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idUnidadEjecutora = await unidadEjecutoraDAO.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if (idUnidadEjecutora <= 0) return await unidadEjecutoraDAO.Crear(request);
                request.idUnidadEjecutora = idUnidadEjecutora;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await unidadEjecutoraDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(UnidadEjecutoraReplica request)
        {
            try
            {
                IUnidadEjecutoraDAO unidadEjecutoraDAO = new UnidadEjecutoraDAO(txtConnectionString);

                if (request.idPliego <= 0 || request.secuenciaUnidadEjecutora <= 0)
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idUnidadEjecutora = await unidadEjecutoraDAO.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if (idUnidadEjecutora > 0)
                    return await unidadEjecutoraDAO.Crear(request);
                request.idUnidadEjecutora = idUnidadEjecutora;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await unidadEjecutoraDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(UnidadEjecutoraReplica request)
        {
            try
            {
                IUnidadEjecutoraDAO unidadEjecutoraDAO = new UnidadEjecutoraDAO(txtConnectionString);

                var idUnidadEjecutora = await unidadEjecutoraDAO.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if (idUnidadEjecutora <= 0)
                    return 1;
                request.idUnidadEjecutora = idUnidadEjecutora;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await unidadEjecutoraDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}