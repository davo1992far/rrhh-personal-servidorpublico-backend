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
    public class EspecialidadProfesionalService : ServiceBase, IEspecialidadProfesionalService
    {
        public EspecialidadProfesionalService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(EspecialidadProfesionalReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IEspecialidadProfesionalDAO especialidadProfesionalDao = new EspecialidadProfesionalDAO(txtConnectionString);

                if (!request.codigoGrupoCarrera.HasValue || request.codigoGrupoCarrera <= 0)
                    request.idGrupoCarrera = null;
                if (request.codigoGrupoCarrera.HasValue && request.codigoGrupoCarrera > 0)
                {
                    var idGrupoCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GRUPO_CARRERA, request.codigoGrupoCarrera.Value);
                    if (idGrupoCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRUPO_CARRERA_NOTFOUND);
                    request.idGrupoCarrera = idGrupoCarrera;
                }

                if (!request.codigoCarreraProfesional.HasValue || request.codigoCarreraProfesional <= 0)
                    request.idCarreraProfesional = null;
                if (request.codigoCarreraProfesional.HasValue && request.codigoCarreraProfesional > 0)
                {
                    var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional.Value);
                    if (idCarreraProfesional <= 0)
                        throw new NotFoundCustomException(Constante.EX_CARRERA_PROFESIONAL_NOTFOUND);
                    request.idCarreraProfesional = idCarreraProfesional;
                }

                var idEspecialidadProfesional = await especialidadProfesionalDao.GetIdEspecialidadProfesionalPorCodigo(request.codigoEspecialidadProfesional);
                if (idEspecialidadProfesional <= 0)
                    return await especialidadProfesionalDao.Crear(request);
                request.idEspecialidadProfesional = idEspecialidadProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await especialidadProfesionalDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(EspecialidadProfesionalReplica request)
        {
            try
            {
                ICarreraProfesionalDAO carreraProfesionalDao = new CarreraProfesionalDAO(txtConnectionString);
                ICatalogoItemDAO catalogoItemDao = new CatalogoItemDAO(txtConnectionString);
                IEspecialidadProfesionalDAO especialidadProfesionalDao = new EspecialidadProfesionalDAO(txtConnectionString);

                if (!request.codigoGrupoCarrera.HasValue || request.codigoGrupoCarrera <= 0)
                    request.idGrupoCarrera = null;
                if (request.codigoGrupoCarrera.HasValue && request.codigoGrupoCarrera > 0)
                {
                    var idGrupoCarrera = await catalogoItemDao.GetIdCatalogoItemPorCodigoCatalogo((int) VariablesGlobales.TablaCatalogo.GRUPO_CARRERA, request.codigoGrupoCarrera.Value);
                    if (idGrupoCarrera <= 0)
                        throw new NotFoundCustomException(Constante.EX_GRUPO_CARRERA_NOTFOUND);
                    request.idGrupoCarrera = idGrupoCarrera;
                }

                if (!request.codigoCarreraProfesional.HasValue || request.codigoCarreraProfesional <= 0)
                    request.idCarreraProfesional = null;
                if (request.codigoCarreraProfesional.HasValue && request.codigoCarreraProfesional > 0)
                {
                    var idCarreraProfesional = await carreraProfesionalDao.GetIdCarreraProfesionalPorCodigo(request.codigoCarreraProfesional.Value);
                    if (idCarreraProfesional <= 0)
                        throw new NotFoundCustomException(Constante.EX_CARRERA_PROFESIONAL_NOTFOUND);
                    request.idCarreraProfesional = idCarreraProfesional;
                }

                var idEspecialidadProfesional = await especialidadProfesionalDao.GetIdEspecialidadProfesionalPorCodigo(request.codigoEspecialidadProfesional);
                if (idEspecialidadProfesional <= 0)
                    return await especialidadProfesionalDao.Crear(request);
                request.idEspecialidadProfesional = idEspecialidadProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await especialidadProfesionalDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(EspecialidadProfesionalReplica request)
        {
            try
            {
                IEspecialidadProfesionalDAO especialidadProfesionalDao = new EspecialidadProfesionalDAO(txtConnectionString);
               
                var idEspecialidadProfesional = await especialidadProfesionalDao.GetIdEspecialidadProfesionalPorCodigo(request.codigoEspecialidadProfesional);
                if (idEspecialidadProfesional <= 0)
                    return 1;
                request.idEspecialidadProfesional = idEspecialidadProfesional;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await especialidadProfesionalDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}