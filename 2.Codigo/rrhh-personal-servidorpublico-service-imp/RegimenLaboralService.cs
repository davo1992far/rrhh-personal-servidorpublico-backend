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
    public class RegimenLaboralService : ServiceBase, IRegimenLaboralService
    {
        public RegimenLaboralService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> CrearReplica(RegimenLaboralReplica request)
        {
            try
            {
                IRegimenLaboralDAO regimenLaboralDAO = new RegimenLaboralDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (!request.codigoTipoRetencionTributaria.HasValue || request.codigoTipoRetencionTributaria <= 0)
                    request.idTipoRetencionTributaria = null;
                if (request.codigoTipoRetencionTributaria.HasValue && request.codigoTipoRetencionTributaria > 0)
                {
                    var idTipoRetencionTributaria =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_RETENCION_TRIBUTARIA, request.codigoTipoRetencionTributaria.Value);
                    if (idTipoRetencionTributaria <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_RETENCION_TRIBUTARIA_NOTFOUND);
                    request.idTipoRetencionTributaria = idTipoRetencionTributaria;
                }

                var regimenLaboral = await regimenLaboralDAO.GetRegimenLaboralPorCodigo(request.codigoRegimenLaboral);
                if (regimenLaboral == null) return await regimenLaboralDAO.Crear(request);
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenLaboralDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarReplica(RegimenLaboralReplica request)
        {
            try
            {
                IRegimenLaboralDAO regimenLaboralDAO = new RegimenLaboralDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (!request.codigoTipoRetencionTributaria.HasValue || request.codigoTipoRetencionTributaria <= 0)
                    request.idTipoRetencionTributaria = null;
                if (request.codigoTipoRetencionTributaria.HasValue && request.codigoTipoRetencionTributaria > 0)
                {
                    var idTipoRetencionTributaria =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_RETENCION_TRIBUTARIA, request.codigoTipoRetencionTributaria.Value);
                    if (idTipoRetencionTributaria <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_RETENCION_TRIBUTARIA_NOTFOUND);
                    request.idTipoRetencionTributaria = idTipoRetencionTributaria;
                }

                var regimenLaboral = await regimenLaboralDAO.GetRegimenLaboralPorCodigo(request.codigoRegimenLaboral);
                if (regimenLaboral == null)
                    return await regimenLaboralDAO.Crear(request);
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenLaboralDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(RegimenLaboralReplica request)
        {
            try
            {
                IRegimenLaboralDAO regimenLaboralDAO = new RegimenLaboralDAO(txtConnectionString);

                var regimenLaboral = await regimenLaboralDAO.GetRegimenLaboralPorCodigo(request.codigoRegimenLaboral);
                if (regimenLaboral == null)
                    return 1;
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenLaboralDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}