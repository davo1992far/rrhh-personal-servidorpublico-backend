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
    public class DreService : ServiceBase, IDreService
    {
        public DreService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> CrearReplica(DreReplica request)
        {
            try
            {
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao=new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                
                if(string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    throw new ValidationCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if(idUnidadEjecutora<=0)
                    throw new ValidationCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                request.idUnidadEjecutora = idUnidadEjecutora;
                
                if (!request.codigoServidorPublico.HasValue || request.codigoServidorPublico <= 0)
                    request.idServidorPublicoDirector = null;
                if (request.codigoServidorPublico.HasValue && request.codigoServidorPublico > 0)
                {
                    var idServidorPublico = await servidorPublicoDao.GetIdServidorPublicoReplicaPorCodigo(request.codigoServidorPublico.Value);
                    if (idServidorPublico <= 0)
                        throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                    request.idServidorPublicoDirector = idServidorPublico;
                }

                if (string.IsNullOrEmpty(request.codigoDistrito))
                    request.idDistrito = null;
                if (!string.IsNullOrEmpty(request.codigoDistrito))
                {
                    var distrito = await distritoDao.GetDistritoPorCodigoInei(request.codigoDistrito);
                    if (distrito == null)
                        throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
                    request.idDistrito = distrito.idDistrito;
                }
                
                var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                if (idDre <= 0) return await dreDAO.Crear(request);
                request.idDre = idDre;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await dreDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarReplica(DreReplica request)
        {
            try
            {
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao=new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                if(string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    throw new ValidationCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if(idUnidadEjecutora<=0)
                    throw new ValidationCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                request.idUnidadEjecutora = idUnidadEjecutora;
                
                if (!request.codigoServidorPublico.HasValue || request.codigoServidorPublico <= 0)
                    request.idServidorPublicoDirector = null;
                if (request.codigoServidorPublico.HasValue && request.codigoServidorPublico > 0)
                {
                    var idServidorPublico = await servidorPublicoDao.GetIdServidorPublicoReplicaPorCodigo(request.codigoServidorPublico.Value);
                    if (idServidorPublico <= 0)
                        throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                    request.idServidorPublicoDirector = idServidorPublico;
                }

                if (string.IsNullOrEmpty(request.codigoDistrito))
                    request.idDistrito = null;
                if (!string.IsNullOrEmpty(request.codigoDistrito))
                {
                    var distrito = await distritoDao.GetDistritoPorCodigoInei(request.codigoDistrito);
                    if (distrito == null)
                        throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
                    request.idDistrito = distrito.idDistrito;
                }
                
                var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                if (idDre <= 0)
                    return await dreDAO.Crear(request);
                request.idDre = idDre;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await dreDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(DreReplica request)
        {
            try
            {
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                if (idDre <= 0)
                    return 1;
                request.idDre = idDre;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await dreDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}