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
    public class TipoCentroTrabajoService : ServiceBase, ITipoCentroTrabajoService
    {
        public TipoCentroTrabajoService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }
        public async Task<int> ActualizarReplica(TipoCentroTrabajoReplica request)
        {
            try
            {
                ITipoCentroTrabajoDAO tipoCentroTrabajoDAO = new TipoCentroTrabajoDAO(txtConnectionString);
                ICatalogoItemDAO catalogoDAO = new CatalogoItemDAO(txtConnectionString);

                if (request.codigoNivelInstancia <= 0)
                    throw new ValidationCustomException(Constante.EX_NIVEL_INSTANCIA_NOTFOUND);
                var idNivelInstancia = await catalogoDAO.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.NIVEL_INSTANCIA, request.codigoNivelInstancia);
                if (idNivelInstancia <= 0)
                    throw new NotFoundCustomException(Constante.EX_NIVEL_INSTANCIA_NOTFOUND);
                request.idNivelInstancia = idNivelInstancia;

                var idTipoCentroTrabajo = await tipoCentroTrabajoDAO.GetIdTipoCentroTrabajoPorCodigo(request.codigoTipoCentroTrabajo, true);
                if (idTipoCentroTrabajo <=0)
                    return await tipoCentroTrabajoDAO.Crear(request);
                request.idTipoCentroTrabajo = idTipoCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await tipoCentroTrabajoDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CrearReplica(TipoCentroTrabajoReplica request)
        {
            try
            {
                ITipoCentroTrabajoDAO tipoCentroTrabajoDAO = new TipoCentroTrabajoDAO(txtConnectionString);
                ICatalogoItemDAO catalogoDAO = new CatalogoItemDAO(txtConnectionString);

                if (request.codigoNivelInstancia <= 0)
                    throw new ValidationCustomException(Constante.EX_NIVEL_INSTANCIA_NOTFOUND);
                var idNivelInstancia = await catalogoDAO.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.NIVEL_INSTANCIA, request.codigoNivelInstancia);
                if (idNivelInstancia <= 0)
                    throw new NotFoundCustomException(Constante.EX_NIVEL_INSTANCIA_NOTFOUND);
                request.idNivelInstancia = idNivelInstancia;

                var idTipoCentroTrabajo = await tipoCentroTrabajoDAO.GetIdTipoCentroTrabajoPorCodigo(request.codigoTipoCentroTrabajo, true);
                if (idTipoCentroTrabajo <=0)
                    return await tipoCentroTrabajoDAO.Crear(request);
                request.idTipoCentroTrabajo = idTipoCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await tipoCentroTrabajoDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(TipoCentroTrabajoReplica request)
        {
            try
            {
                ITipoCentroTrabajoDAO tipoCentroTrabajoDAO = new TipoCentroTrabajoDAO(txtConnectionString);
                var idTipoCentroTrabajo = await tipoCentroTrabajoDAO.GetIdTipoCentroTrabajoPorCodigo(request.codigoTipoCentroTrabajo, true);
                if (idTipoCentroTrabajo <=0)
                    return 1;
                request.idTipoCentroTrabajo = idTipoCentroTrabajo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await tipoCentroTrabajoDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}