using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model.replica;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class CategoriaRemunerativaService: ServiceBase, ICategoriaRemunerativaService
    {
        public CategoriaRemunerativaService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> Crear(CategoriaRemunerativaReplica request)
        {
            try
            {
                ICategoriaRemunerativaDAO categoriaRemunerativaDao = new CategoriaRemunerativaDAO(txtConnectionString);

                var categoriaRemunerativa = await categoriaRemunerativaDao.GetCategoriaRemunerativaPorCodigo(request.codigoCategoriaRemunerativa);
                if (categoriaRemunerativa == null) return await categoriaRemunerativaDao.Crear(request);
                request.idCategoriaRemunerativa = categoriaRemunerativa.idCategoriaRemunerativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await categoriaRemunerativaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Actualizar(CategoriaRemunerativaReplica request)
        {
            try
            {
                ICategoriaRemunerativaDAO categoriaRemunerativaDao = new CategoriaRemunerativaDAO(txtConnectionString);
                var categoriaRemunerativa = await categoriaRemunerativaDao.GetCategoriaRemunerativaPorCodigo(request.codigoCategoriaRemunerativa);
                if (categoriaRemunerativa == null)
                    return await categoriaRemunerativaDao.Crear(request);
                request.idCategoriaRemunerativa = categoriaRemunerativa.idCategoriaRemunerativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await categoriaRemunerativaDao.Actualizar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Eliminar(CategoriaRemunerativaReplica request)
        {
            try
            {
                ICategoriaRemunerativaDAO categoriaRemunerativaDao = new CategoriaRemunerativaDAO(txtConnectionString);

                var categoriaRemunerativa = await categoriaRemunerativaDao.GetCategoriaRemunerativaPorCodigo(request.codigoCategoriaRemunerativa);
                if (categoriaRemunerativa == null)
                    return 1;
                request.idCategoriaRemunerativa = categoriaRemunerativa.idCategoriaRemunerativa;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await categoriaRemunerativaDao.Eliminar(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}