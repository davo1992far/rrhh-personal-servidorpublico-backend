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
    public class JornadaLaboralService : ServiceBase, IJornadaLaboralService
    {
        public JornadaLaboralService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(JornadaLaboralReplica request)
        {
            try
            {
                IJornadaLaboralDAO jornadaLaboralDao = new JornadaLaboralDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (request.codigoJornadaLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_JORNADA_LABORAL_NOTFOUND);

                if (!request.codigoTipoJornadaLaboral.HasValue || request.codigoTipoJornadaLaboral <= 0)
                    request.idTipoJornadaLaboral = null;
                if (request.codigoTipoJornadaLaboral.HasValue && request.codigoTipoJornadaLaboral > 0)
                {
                    var idTipoJornadaLaboral =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_JORNADA_LABORAL, request.codigoTipoJornadaLaboral.Value);
                    if (idTipoJornadaLaboral <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_JORNADA_LABORAL_NOTFOUND);
                    request.idTipoJornadaLaboral = idTipoJornadaLaboral;
                }

                var jornadaLaboral = await jornadaLaboralDao.GetJornadaLaboralPorCodigo(request.codigoJornadaLaboral);
                if (jornadaLaboral == null)
                    return await jornadaLaboralDao.Crear(request);
                request.idJornadaLaboral = jornadaLaboral.idJornadaLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await jornadaLaboralDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(JornadaLaboralReplica request)
        {
            try
            {
                IJornadaLaboralDAO jornadaLaboralDao = new JornadaLaboralDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                
                if (request.codigoJornadaLaboral <= 0)
                    throw new ValidationCustomException(Constante.EX_JORNADA_LABORAL_NOTFOUND);
                
                if (!request.codigoTipoJornadaLaboral.HasValue || request.codigoTipoJornadaLaboral <= 0)
                    request.idTipoJornadaLaboral = null;
                if (request.codigoTipoJornadaLaboral.HasValue && request.codigoTipoJornadaLaboral > 0)
                {
                    var idTipoJornadaLaboral =
                        await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.TIPO_JORNADA_LABORAL, request.codigoTipoJornadaLaboral.Value);
                    if (idTipoJornadaLaboral <= 0)
                        throw new NotFoundCustomException(Constante.EX_TIPO_JORNADA_LABORAL_NOTFOUND);
                    request.idTipoJornadaLaboral = idTipoJornadaLaboral;
                }
                var jornadaLaboral = await jornadaLaboralDao.GetJornadaLaboralPorCodigo(request.codigoJornadaLaboral);
                if (jornadaLaboral == null)
                    return await jornadaLaboralDao.Crear(request);
                request.idJornadaLaboral = jornadaLaboral.idJornadaLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await jornadaLaboralDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(JornadaLaboralReplica request)
        {
            try
            {
                IJornadaLaboralDAO jornadaLaboralDao = new JornadaLaboralDAO(txtConnectionString);

                var jornadaLaboral = await jornadaLaboralDao.GetJornadaLaboralPorCodigo(request.codigoJornadaLaboral);
                if (jornadaLaboral == null)
                    return 1;
                request.idJornadaLaboral = jornadaLaboral.idJornadaLaboral;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await jornadaLaboralDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}