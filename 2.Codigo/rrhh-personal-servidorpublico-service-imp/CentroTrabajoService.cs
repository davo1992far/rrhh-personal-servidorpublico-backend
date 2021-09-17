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
    public class CentroTrabajoService : ServiceBase, ICentroTrabajoService
    {
        public CentroTrabajoService(string txtConnectionString)
        {
            base.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(CentroTrabajoReplica request)
        {
            try
            {
                ICentroTrabajoDAO centroTrabajoDAO = new CentroTrabajoDAO(txtConnectionString);
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                ITipoCentroTrabajoDAO tipoCentroTrabajoDao = new TipoCentroTrabajoDAO(txtConnectionString);
                IOtraInstanciaDAO otraInstanciaDao = new OtraInstanciaDAO(txtConnectionString);
                IInstitucionEducativaDAO institucionEducativaDao = new InstitucionEducativaDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoOtraInstancia))
                    request.idOtraInstancia = null;
                if (!string.IsNullOrEmpty(request.codigoOtraInstancia))
                {
                    var idOtraInstancia = await otraInstanciaDao.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                    if (idOtraInstancia <= 0)
                        throw new NotFoundCustomException(Constante.EX_OTRA_INSTANCIA_NOTFOUND);
                    request.idOtraInstancia = idOtraInstancia;
                }

                if (string.IsNullOrEmpty(request.codigoTipoCentroTrabajo))
                    throw new NotFoundCustomException(Constante.EX_TIPO_CENTRO_TRABAJO_NOTFOUND);
                var idTipoCentroTrabajo = await tipoCentroTrabajoDao.GetIdTipoCentroTrabajoPorCodigo(request.codigoTipoCentroTrabajo, true);
                if (idTipoCentroTrabajo <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_CENTRO_TRABAJO_NOTFOUND);
                request.idTipoCentroTrabajo = idTipoCentroTrabajo;

                if (string.IsNullOrEmpty(request.codigoDre))
                    request.idDre = null;
                if (!string.IsNullOrEmpty(request.codigoDre))
                {
                    var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                    if (idDre <= 0)
                        throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                    request.idDre = idDre;
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

                if (string.IsNullOrEmpty(request.codigoModular))
                    request.idInstitucionEducativa = null;
                if (!string.IsNullOrEmpty(request.codigoModular))
                {
                    var idInstitucionEducativa = await institucionEducativaDao.GetIdInstitucionEducativaPorCodigo(request.codigoModular, request.anexoCentroTrabajo, true);
                    if (idInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idInstitucionEducativa = idInstitucionEducativa;
                }

                var centroTrabajo = await centroTrabajoDAO.GetCentroTrabajoPorCodigo(request.codigoCentroTrabajo, request.anexoCentroTrabajo);
                if (centroTrabajo == null) return await centroTrabajoDAO.Crear(request);
                request.idCentroTrabajo = centroTrabajo.idCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroTrabajoDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(CentroTrabajoReplica request)
        {
            try
            {
                ICentroTrabajoDAO centroTrabajoDAO = new CentroTrabajoDAO(txtConnectionString);
                IDreDAO dreDAO = new DreDAO(txtConnectionString);
                IUgelDAO ugelDAO = new UgelDAO(txtConnectionString);
                ITipoCentroTrabajoDAO tipoCentroTrabajoDao = new TipoCentroTrabajoDAO(txtConnectionString);
                IOtraInstanciaDAO otraInstanciaDao = new OtraInstanciaDAO(txtConnectionString);
                IInstitucionEducativaDAO institucionEducativaDao = new InstitucionEducativaDAO(txtConnectionString);

                if (string.IsNullOrEmpty(request.codigoOtraInstancia))
                    request.idOtraInstancia = null;
                if (!string.IsNullOrEmpty(request.codigoOtraInstancia))
                {
                    var idOtraInstancia = await otraInstanciaDao.GetIdOtraInstanciaPorCodigo(request.codigoOtraInstancia, true);
                    if (idOtraInstancia <= 0)
                        throw new NotFoundCustomException(Constante.EX_OTRA_INSTANCIA_NOTFOUND);
                    request.idOtraInstancia = idOtraInstancia;
                }

                if (string.IsNullOrEmpty(request.codigoTipoCentroTrabajo))
                    throw new NotFoundCustomException(Constante.EX_TIPO_CENTRO_TRABAJO_NOTFOUND);
                var idTipoCentroTrabajo = await tipoCentroTrabajoDao.GetIdTipoCentroTrabajoPorCodigo(request.codigoTipoCentroTrabajo, true);
                if (idTipoCentroTrabajo <= 0)
                    throw new NotFoundCustomException(Constante.EX_TIPO_CENTRO_TRABAJO_NOTFOUND);
                request.idTipoCentroTrabajo = idTipoCentroTrabajo;

                if (string.IsNullOrEmpty(request.codigoDre))
                    request.idDre = null;
                if (!string.IsNullOrEmpty(request.codigoDre))
                {
                    var idDre = await dreDAO.GetIdDrePorCodigo(request.codigoDre, true);
                    if (idDre <= 0)
                        throw new NotFoundCustomException(Constante.EX_DRE_NOTFOUND);
                    request.idDre = idDre;
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

                if (string.IsNullOrEmpty(request.codigoModular))
                    request.idInstitucionEducativa = null;
                if (!string.IsNullOrEmpty(request.codigoModular))
                {
                    var idInstitucionEducativa = await institucionEducativaDao.GetIdInstitucionEducativaPorCodigo(request.codigoModular, request.anexoCentroTrabajo, true);
                    if (idInstitucionEducativa <= 0)
                        throw new NotFoundCustomException(Constante.EX_INSTITUCION_EDUCATIVA_NOTFOUND);
                    request.idInstitucionEducativa = idInstitucionEducativa;
                }


                var centroTrabajo = await centroTrabajoDAO.GetCentroTrabajoPorCodigo(request.codigoCentroTrabajo, request.anexoCentroTrabajo);
                if (centroTrabajo == null)
                    return await centroTrabajoDAO.Crear(request);
                request.idCentroTrabajo = centroTrabajo.idCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroTrabajoDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(CentroTrabajoReplica request)
        {
            try
            {
                ICentroTrabajoDAO centroTrabajoDAO = new CentroTrabajoDAO(txtConnectionString);
             
                var centroTrabajo = await centroTrabajoDAO.GetCentroTrabajoPorCodigo(request.codigoCentroTrabajo, request.anexoCentroTrabajo);
                if (centroTrabajo == null)
                    return 1;
                request.idCentroTrabajo = centroTrabajo.idCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await centroTrabajoDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}