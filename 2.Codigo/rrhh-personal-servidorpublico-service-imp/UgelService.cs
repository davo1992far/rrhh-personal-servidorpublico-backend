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
    public class UgelService : ServiceBase, IUgelService
    {
        public UgelService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> ActualizarReplica(UgelReplica request)
        {
            try
            {
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                IDreDAO dredAO = new DreDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoDre))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);
                var idDre = await dredAO.GetIdDrePorCodigo(request.codigoDre, true);
                if (idDre <= 0)
                    throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                request.idDre = idDre;

                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);
                var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if (idUnidadEjecutora <= 0)
                    throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
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

                var idUgel = await ugelDAO.GetIdUgelPorCodigo(request.codigoUgel, true);
                if (idUgel <= 0) return await ugelDAO.Crear(request);
                request.idUgel = idUgel;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await ugelDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CrearReplica(UgelReplica request)
        {
            try
            {
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                IDreDAO dredAO = new DreDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                var idDre = await dredAO.GetIdDrePorCodigo(request.codigoDre, true);
                if (idDre <= 0)
                    throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                request.idDre = idDre;

                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);
                var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                if (idUnidadEjecutora <= 0)
                    throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
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

                var idUgel = await ugelDAO.GetIdUgelPorCodigo(request.codigoUgel, true);
                if (idUgel <= 0) return await ugelDAO.Crear(request);
                request.idUgel = idUgel;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await ugelDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(UgelReplica request)
        {
            try
            {
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                var idUgel = await ugelDAO.GetIdUgelPorCodigo(request.codigoUgel, true);
                if (idUgel <= 0)
                    return 1;
                request.idUgel = idUgel;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await ugelDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}