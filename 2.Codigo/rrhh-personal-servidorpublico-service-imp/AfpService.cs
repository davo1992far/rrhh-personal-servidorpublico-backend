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
    public class AfpService : ServiceBase, IAfpService
    {
        public AfpService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(AfpReplica request)
        {
            try
            {
                IAfpDAO afpDao = new AfpDAO(txtConnectionString);
                IRegimenPensionarioDAO regimenPensionarioDao = new RegimenPensionarioDAO(txtConnectionString);

                if (request.codigoRegimenPensionario <= 0)
                    throw new ValidationCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);
                var regimenPensionario = await regimenPensionarioDao.GetRegimenPensionarioPorCodigo(request.codigoRegimenPensionario);
                if (regimenPensionario == null)
                    throw new NotFoundCustomException(Constante.EX_REGIMEN_PENSIONARIO_NOTFOUND);
                request.idRegimenPensionario = regimenPensionario.idRegimenPensionario;
                
                var afp = await afpDao.GetAfpPorCodigo(request.codigoAfp);
                if (afp == null)
                    return await afpDao.Crear(request);
                request.idAfp = afp.idAfp;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await afpDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(AfpReplica request)
        {
            try
            {
                return await Crear(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(AfpReplica request)
        {
            try
            {
                IAfpDAO afpDao = new AfpDAO(txtConnectionString);

                var afp = await afpDao.GetAfpPorCodigo(request.codigoAfp);
                if (afp == null)
                    return 1;
                request.idAfp = afp.idAfp;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await afpDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}