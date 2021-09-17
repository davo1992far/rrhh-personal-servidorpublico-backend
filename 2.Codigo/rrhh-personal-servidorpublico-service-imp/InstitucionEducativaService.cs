using System;
using System.Threading.Tasks;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro.rrhh_negocio_comunes_maestros_backend;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class InstitucionEducativaService : ServiceBase, IInstitucionEducativaService
    {
        public InstitucionEducativaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> ActualizarReplica(InstitucionEducativaReplica request)
        {
            try
            {
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                IOtraInstanciaDAO otraInstanciaDao = new OtraInstanciaDAO(txtConnectionString);
                INivelEducativoDAO nivelEducativoDAO = new NivelEducativoDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IInstitucionEducativaDAO institucionEducativaDao = new InstitucionEducativaDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoDistrito))
                    request.idDistrito = null;
                if (!string.IsNullOrEmpty(request.codigoDistrito))
                {
                    var distrito = await distritoDao.GetDistritoPorCodigoInei(request.codigoDistrito);
                    if (distrito == null)
                        throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
                    request.idDistrito = distrito.idDistrito;
                }

                if (string.IsNullOrEmpty(request.codigoUgel))
                    request.idUgel = null;
                if (!string.IsNullOrEmpty(request.codigoUgel))
                {
                    var idUgel = await ugelDAO.GetIdUgelPorCodigo(request.codigoUgel, true);
                    if (idUgel <= 0)
                        throw new NotFoundCustomException(Constante.EX_UGEL_NOTFOUND);
                    request.idUgel = idUgel;
                }

                if (string.IsNullOrEmpty(request.codigoDre))
                    request.idDre = null;
                if (!string.IsNullOrEmpty(request.codigoDre))
                {
                    var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                    if (idDre <= 0)
                        throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                    request.idDre = idDre;
                }

                if (string.IsNullOrEmpty(request.codigoOtraInstancia))
                    request.idOtraInstancia = null;
                if (!string.IsNullOrEmpty(request.codigoOtraInstancia))
                {
                    var idOtraInstancia = await otraInstanciaDao.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                    if (idOtraInstancia <= 0)
                        throw new NotFoundCustomException(Constante.EX_OTRA_INSTANCIA_NOTFOUND);
                    request.idOtraInstancia = idOtraInstancia;
                }

                if (string.IsNullOrEmpty(request.codigoNivelEducativo))
                    request.idNivelEducativo = null;
                if (!string.IsNullOrEmpty(request.codigoNivelEducativo))
                {
                    var idNivelEducativo = await nivelEducativoDAO.GetNivelEducativoByCodigo(request.codigoNivelEducativo);
                    if (idNivelEducativo <= 0)
                        throw new NotFoundCustomException(Constante.EX_NIVEL_EDUCATIVO_NOTFOUND);
                    request.idNivelEducativo = idNivelEducativo;
                }


                if (!request.codigoTipoInstitucionEducativa.HasValue || request.codigoTipoInstitucionEducativa <= 0)
                    request.idTipoInstitucionEducativa = null;
                if (request.codigoTipoInstitucionEducativa.HasValue && request.codigoTipoInstitucionEducativa > 0)
                {
                    var idTipoInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_INSTITUCION_EDUCATIVA, request.codigoTipoInstitucionEducativa.Value);
                    if (idTipoInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idTipoInstitucionEducativa = idTipoInstitucionEducativa;
                }

                if (!request.codigoDependenciaInstitucionEducativa.HasValue || request.codigoDependenciaInstitucionEducativa <= 0)
                    request.idDependenciaInstitucionEducativa = null;
                if (request.codigoDependenciaInstitucionEducativa.HasValue && request.codigoDependenciaInstitucionEducativa > 0)
                {
                    var idDependenciaInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.DEPENDENCIA_INSTITUCION_EDUCATIVA,
                            request.codigoDependenciaInstitucionEducativa.Value);
                    if (idDependenciaInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_DEPENDENCIA_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idDependenciaInstitucionEducativa = idDependenciaInstitucionEducativa;
                }

                if (!request.codigoTipoGestionInstitucionEducativa.HasValue || request.codigoTipoGestionInstitucionEducativa <= 0)
                    request.idTipoGestionInstitucionEducativa = null;
                if (request.codigoTipoGestionInstitucionEducativa.HasValue && request.codigoTipoGestionInstitucionEducativa > 0)
                {
                    var idTipoGestionInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_GESTION_INSTITUCION_EDUCATIVA,
                            request.codigoTipoGestionInstitucionEducativa.Value);
                    if (idTipoGestionInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_GESTION_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idTipoGestionInstitucionEducativa = idTipoGestionInstitucionEducativa;
                }

                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    request.idUnidadEjecutora = null;
                if (!string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                {
                    var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                    if (idUnidadEjecutora <= 0)
                        throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                    request.idUnidadEjecutora = idUnidadEjecutora;
                }

                if (!request.codigoServidorPublico.HasValue || request.codigoServidorPublico <= 0)
                    request.idServidorPublicoDirector = null;
                if (request.codigoServidorPublico.HasValue && request.codigoServidorPublico > 0)
                {
                    var idServidorPublico = await servidorPublicoDao.GetIdServidorPublicoReplicaPorCodigo(request.codigoServidorPublico.Value);
                    if (idServidorPublico <= 0)
                        throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                    request.idServidorPublicoDirector = idServidorPublico;
                }

                if (string.IsNullOrEmpty(request.institucionEducativa) || string.IsNullOrEmpty(request.codigoModular))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idInstitucionEducativa = await institucionEducativaDao.GetIdInstitucionEducativaPorCodigo(request.codigoModular, request.anexoInstitucionEducativa, true);
                if (idInstitucionEducativa <= 0)
                    return await institucionEducativaDao.Crear(request);
                request.idInstitucionEducativa = idInstitucionEducativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await institucionEducativaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CrearReplica(InstitucionEducativaReplica request)
        {
            try
            {
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                IOtraInstanciaDAO otraInstanciaDao = new OtraInstanciaDAO(txtConnectionString);
                INivelEducativoDAO nivelEducativoDAO = new NivelEducativoDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IInstitucionEducativaDAO institucionEducativaDao = new InstitucionEducativaDAO(txtConnectionString);
                IUnidadEjecutoraDAO unidadEjecutoraDao = new UnidadEjecutoraDAO(txtConnectionString);
                IServidorPublicoDAO servidorPublicoDao = new ServidorPublicoDAO(txtConnectionString);
                IDistritoDAO distritoDao = new DistritoDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoDistrito))
                    request.idDistrito = null;
                if (!string.IsNullOrEmpty(request.codigoDistrito))
                {
                    var distrito = await distritoDao.GetDistritoPorCodigoInei(request.codigoDistrito);
                    if (distrito == null)
                        throw new NotFoundCustomException(Constante.EX_DISTRITO_NOT_FOUND);
                    request.idDistrito = distrito.idDistrito;
                }
                
                if (string.IsNullOrEmpty(request.codigoUgel))
                    request.idUgel = null;
                if (!string.IsNullOrEmpty(request.codigoUgel))
                {
                    var idUgel = await ugelDAO.GetIdUgelPorCodigo(request.codigoUgel, true);
                    if (idUgel <= 0)
                        throw new NotFoundCustomException(Constante.EX_UGEL_NOTFOUND);
                    request.idUgel = idUgel;
                }

                if (string.IsNullOrEmpty(request.codigoDre))
                    request.idDre = null;
                if (!string.IsNullOrEmpty(request.codigoDre))
                {
                    var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                    if (idDre <= 0)
                        throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                    request.idDre = idDre;
                }

                if (string.IsNullOrEmpty(request.codigoOtraInstancia))
                    request.idOtraInstancia = null;
                if (!string.IsNullOrEmpty(request.codigoOtraInstancia))
                {
                    var idOtraInstancia = await otraInstanciaDao.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                    if (idOtraInstancia <= 0)
                        throw new NotFoundCustomException(Constante.EX_OTRA_INSTANCIA_NOTFOUND);
                    request.idOtraInstancia = idOtraInstancia;
                }

                if (string.IsNullOrEmpty(request.codigoNivelEducativo))
                    request.idNivelEducativo = null;
                if (!string.IsNullOrEmpty(request.codigoNivelEducativo))
                {
                    var idNivelEducativo = await nivelEducativoDAO.GetNivelEducativoByCodigo(request.codigoNivelEducativo);
                    if (idNivelEducativo <= 0)
                        throw new NotFoundCustomException(Constante.EX_NIVEL_EDUCATIVO_NOTFOUND);
                    request.idNivelEducativo = idNivelEducativo;
                }


                if (!request.codigoTipoInstitucionEducativa.HasValue || request.codigoTipoInstitucionEducativa <= 0)
                    request.idTipoInstitucionEducativa = null;
                if (request.codigoTipoInstitucionEducativa.HasValue && request.codigoTipoInstitucionEducativa > 0)
                {
                    var idTipoInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_INSTITUCION_EDUCATIVA, request.codigoTipoInstitucionEducativa.Value);
                    if (idTipoInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idTipoInstitucionEducativa = idTipoInstitucionEducativa;
                }

                if (!request.codigoDependenciaInstitucionEducativa.HasValue || request.codigoDependenciaInstitucionEducativa <= 0)
                    request.idDependenciaInstitucionEducativa = null;
                if (request.codigoDependenciaInstitucionEducativa.HasValue && request.codigoDependenciaInstitucionEducativa > 0)
                {
                    var idDependenciaInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.DEPENDENCIA_INSTITUCION_EDUCATIVA,
                            request.codigoDependenciaInstitucionEducativa.Value);
                    if (idDependenciaInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_DEPENDENCIA_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idDependenciaInstitucionEducativa = idDependenciaInstitucionEducativa;
                }

                if (!request.codigoTipoGestionInstitucionEducativa.HasValue || request.codigoTipoGestionInstitucionEducativa <= 0)
                    request.idTipoGestionInstitucionEducativa = null;
                if (request.codigoTipoGestionInstitucionEducativa.HasValue && request.codigoTipoGestionInstitucionEducativa > 0)
                {
                    var idTipoGestionInstitucionEducativa =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_GESTION_INSTITUCION_EDUCATIVA,
                            request.codigoTipoGestionInstitucionEducativa.Value);
                    if (idTipoGestionInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_GESTION_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idTipoGestionInstitucionEducativa = idTipoGestionInstitucionEducativa;
                }


                if (string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                    request.idUnidadEjecutora = null;
                if (!string.IsNullOrEmpty(request.codigoUnidadEjecutora))
                {
                    var idUnidadEjecutora = await unidadEjecutoraDao.BuscarUnidadEjecutoraCodigo(request.codigoUnidadEjecutora);
                    if (idUnidadEjecutora <= 0)
                        throw new NotFoundCustomException(Constante.EX_UNIDAD_EJECUTORA_NOTFOUND);
                    request.idUnidadEjecutora = idUnidadEjecutora;
                }

                if (!request.codigoServidorPublico.HasValue || request.codigoServidorPublico <= 0)
                    request.idServidorPublicoDirector = null;
                if (request.codigoServidorPublico.HasValue && request.codigoServidorPublico > 0)
                {
                    var idServidorPublico = await servidorPublicoDao.GetIdServidorPublicoReplicaPorCodigo(request.codigoServidorPublico.Value);
                    if (idServidorPublico <= 0)
                        throw new NotFoundCustomException(Constante.EX_SERVIDOR_PUBLICO_NOT_FOUND);
                    request.idServidorPublicoDirector = idServidorPublico;
                }

                if (string.IsNullOrEmpty(request.institucionEducativa) || string.IsNullOrEmpty(request.codigoModular))
                    throw new ValidationCustomException(Constante.EX_ENTITY_REQUERID);

                var idInstitucionEducativa = await institucionEducativaDao.GetIdInstitucionEducativaPorCodigo(request.codigoModular, request.anexoInstitucionEducativa, true);
                if (idInstitucionEducativa <= 0)
                    return await institucionEducativaDao.Crear(request);
                request.idInstitucionEducativa = idInstitucionEducativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await institucionEducativaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(InstitucionEducativaReplica request)
        {
            IInstitucionEducativaDAO institucionEducativaDAO = new InstitucionEducativaDAO(txtConnectionString);
            var idInstitucionEducativa = await institucionEducativaDAO.GetIdInstitucionEducativaPorCodigo(request.codigoModular, request.anexoInstitucionEducativa, true);
            if (idInstitucionEducativa <= 0)
                return 1;
            request.idInstitucionEducativa = idInstitucionEducativa;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await institucionEducativaDAO.Eliminar(request);
        }

        #endregion
    }
}