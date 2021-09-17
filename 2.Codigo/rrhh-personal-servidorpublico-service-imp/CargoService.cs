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
    public class CargoService : ServiceBase, ICargoService
    {
        public CargoService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(CargoReplica request)
        {
            try
            {
                ICargoDAO cargoDAO = new CargoDAO(txtConnectionString);
                IRegimenLaboralDAO regimenLaboralDao = new RegimenLaboralDAO(txtConnectionString);

                var regimenLaboral = await regimenLaboralDao.GetRegimenLaboralPorCodigo(request.CodigoRegimenLaboral);
                if (regimenLaboral == null)
                    throw new NotFoundCustomException(Constante.EX_REGIMEN_LABORAL_NOTFOUND);
                request.idRegimenLaboral = regimenLaboral.idRegimenLaboral;

                var idCargo = await cargoDAO.GetIdCargoPorCodigo(request.codigoCargo, true);
                if (idCargo <= 0) return await cargoDAO.Crear(request);
                request.idCargo = idCargo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await cargoDAO.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(CargoReplica request)
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

        public async Task<int> Eliminar(CargoReplica request)
        {
            try
            {
                ICargoDAO cargoDAO = new CargoDAO(txtConnectionString);

                var idCargo = await cargoDAO.GetIdCargoPorCodigo(request.codigoCargo, true);
                if (idCargo <= 0)
                    return 1;
                request.idCargo = idCargo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await cargoDAO.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}