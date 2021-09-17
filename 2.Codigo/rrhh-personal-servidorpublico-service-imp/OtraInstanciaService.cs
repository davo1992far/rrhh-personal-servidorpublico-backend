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
    public class OtraInstanciaService : ServiceBase, IOtraInstanciaService
    {
        public OtraInstanciaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> Crear(OtraInstanciaReplica request)
        {
            try
            {
                IOtraInstanciaDAO otraInstanciaDAO = new OtraInstanciaDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    request.idUnidadEjecutora = null;
                if (!string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                {
                    var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                    if (idUnidadEjecutora <= 0)
                        throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                    request.idUnidadEjecutora = idUnidadEjecutora;
                }

                var idOtraInstancia = await otraInstanciaDAO.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                if (idOtraInstancia <= 0) return await otraInstanciaDAO.Crear(request);
                request.idOtraInstancia = idOtraInstancia;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await otraInstanciaDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(OtraInstanciaReplica request)
        {
            try
            {
                IOtraInstanciaDAO otraInstanciaDAO = new OtraInstanciaDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    request.idUnidadEjecutora = null;
                if (!string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                {
                    var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                    if (idUnidadEjecutora <= 0)
                        throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                    request.idUnidadEjecutora = idUnidadEjecutora;
                }

                var idOtraInstancia = await otraInstanciaDAO.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                if (idOtraInstancia <= 0) return await otraInstanciaDAO.Crear(request);
                request.idOtraInstancia = idOtraInstancia;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await otraInstanciaDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(OtraInstanciaReplica request)
        {
            try
            {
                IOtraInstanciaDAO otraInstanciaDAO = new OtraInstanciaDAO(txtConnectionString);
                var idOtraInstancia = await otraInstanciaDAO.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                if (idOtraInstancia <= 0)
                    return 1;
                request.idOtraInstancia = idOtraInstancia;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await otraInstanciaDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}