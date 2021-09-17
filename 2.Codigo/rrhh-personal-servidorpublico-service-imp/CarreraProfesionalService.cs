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
    public class CarreraProfesionalService : ServiceBase, ICarreraProfesionalService
    {
        public CarreraProfesionalService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(CarreraProfesionalReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (!request.codigoGrupoCarrera.HasValue || request.codigoGrupoCarrera <= 0)
                    request.idGrupoCarrera = null;
                if (request.codigoGrupoCarrera.HasValue && request.codigoGrupoCarrera > 0)
                {
                    var idGrupoCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GRUPO_CARRERA, request.codigoGrupoCarrera.Value);
                    if (idGrupoCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRUPO_CARRERA_NOTFOUND);
                    request.idGrupoCarrera = idGrupoCarrera;
                }

                if (request.codigoCarreraProfesional <= 0)
                    throw new ValidationCustomException(Constante.EX_CARRERA_PROFESIONAL_NOTFOUND);

                var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional);
                if (idCarreraProfesional <= 0)
                    return await carreraProfesionalDao.Crear(request);
                request.idCarreraProfesional = idCarreraProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await carreraProfesionalDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(CarreraProfesionalReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);

                if (!request.codigoGrupoCarrera.HasValue || request.codigoGrupoCarrera <= 0)
                    request.idGrupoCarrera = null;
                if (request.codigoGrupoCarrera.HasValue && request.codigoGrupoCarrera > 0)
                {
                    var idGrupoCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GRUPO_CARRERA, request.codigoGrupoCarrera.Value);
                    if (idGrupoCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRUPO_CARRERA_NOTFOUND);
                    request.idGrupoCarrera = idGrupoCarrera;
                }

                if (request.codigoCarreraProfesional <= 0)
                    throw new ValidationCustomException(Constante.EX_CARRERA_PROFESIONAL_NOTFOUND);

                var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional);
                if (idCarreraProfesional <= 0)
                    return await carreraProfesionalDao.Crear(request);
                request.idCarreraProfesional = idCarreraProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await carreraProfesionalDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(CarreraProfesionalReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);

            
                var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional);
                if (idCarreraProfesional <= 0)
                    return 1;
                request.idCarreraProfesional = idCarreraProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await carreraProfesionalDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}