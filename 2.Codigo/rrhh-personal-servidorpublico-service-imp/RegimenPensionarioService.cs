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
    public class RegimenPensionarioService : ServiceBase, IRegimenPensionarioService
    {
        public RegimenPensionarioService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> Crear(RegimenPensionarioReplica request)
        {
            try
            {
                IRegimenPensionarioDAO regimenPensionarioDao = new RegimenPensionarioDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                if (request.codigoRegimenPensionario <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);

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

                var regimenPensionario = await regimenPensionarioDao.GetRegimenPensionarioPorCodigo(request.codigoRegimenPensionario);
                if (regimenPensionario == null) return await regimenPensionarioDao.Crear(request);
                request.idRegimenPensionario = regimenPensionario.idRegimenPensionario;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenPensionarioDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(RegimenPensionarioReplica request)
        {
            try
            {
                IRegimenPensionarioDAO regimenPensionarioDao = new RegimenPensionarioDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                if (request.codigoRegimenPensionario <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);
                
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
                
                var regimenPensionario = await regimenPensionarioDao.GetRegimenPensionarioPorCodigo(request.codigoRegimenPensionario);
                if (regimenPensionario == null) return await regimenPensionarioDao.Crear(request);
                request.idRegimenPensionario = regimenPensionario.idRegimenPensionario;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenPensionarioDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(RegimenPensionarioReplica request)
        {
            try
            {
                IRegimenPensionarioDAO regimenPensionarioDao = new RegimenPensionarioDAO(txtConnectionString);

                if (request.codigoRegimenPensionario <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);

                var regimenPensionario = await regimenPensionarioDao.GetRegimenPensionarioPorCodigo(request.codigoRegimenPensionario);
                if (regimenPensionario == null)
                    return 1;
                request.idRegimenPensionario = regimenPensionario.idRegimenPensionario;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await regimenPensionarioDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}