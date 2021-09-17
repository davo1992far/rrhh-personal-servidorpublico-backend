using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class GradoInstruccionService : ServiceBase, IGradoInstruccionService
    {
        public GradoInstruccionService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        #region replica

        public async Task<int> Crear(GradoInstruccionReplica request)
        {
            try
            {
                IGradoInstruccionDAO gradoInstruccionDao = new GradoInstruccionDAO(txtConnectionString);

             
                var idGradoInstruccion = await gradoInstruccionDao.GetIdGradoInstruccionPorCodigo(request.codigoGradoInstruccion);
                if (idGradoInstruccion <= 0)
                    return await gradoInstruccionDao.Crear(request);
                request.idGradoInstruccion = idGradoInstruccion;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await gradoInstruccionDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(GradoInstruccionReplica request)
        {
            try
            {
                IGradoInstruccionDAO gradoInstruccionDao = new GradoInstruccionDAO(txtConnectionString);

              
                var idGradoInstruccion = await gradoInstruccionDao.GetIdGradoInstruccionPorCodigo(request.codigoGradoInstruccion);
                if (idGradoInstruccion <= 0)
                    return await gradoInstruccionDao.Crear(request);
                request.idGradoInstruccion = idGradoInstruccion;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await gradoInstruccionDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(GradoInstruccionReplica request)
        {
            try
            {
                IGradoInstruccionDAO gradoInstruccionDao = new GradoInstruccionDAO(txtConnectionString);

                var idGradoInstruccion = await gradoInstruccionDao.GetIdGradoInstruccionPorCodigo(request.codigoGradoInstruccion);
                if (idGradoInstruccion <= 0)
                    return 1;
                request.idGradoInstruccion = idGradoInstruccion;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await gradoInstruccionDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}