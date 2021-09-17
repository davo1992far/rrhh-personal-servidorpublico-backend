using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class CatalogoService : ServiceBase, ICatalogoService
    {
        public CatalogoService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }

        public async Task<int> CrearReplica(Catalogo request)
        {
            try
            {
                ICatalogoDAO catalogoDao = new CatalogoDAO(txtConnectionString);

                var catalogo = await catalogoDao.GetCatalogoPorCodigo(request.codigoCatalogo);
                if (catalogo == null)
                    return await catalogoDao.CrearCatalogo(request);
                request.idCatalogo = catalogo.idCatalogo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await catalogoDao.ActualizarCatalogo(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarReplica(Catalogo request)
        {
            try
            {
                ICatalogoDAO catalogoDao = new CatalogoDAO(txtConnectionString);
                
                var catalogo = await catalogoDao.GetCatalogoPorCodigo(request.codigoCatalogo);
                if (catalogo == null)
                    return await catalogoDao.CrearCatalogo(request);
                request.idCatalogo = catalogo.idCatalogo;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await catalogoDao.ActualizarCatalogo(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(Catalogo request)
        {
            ICatalogoDAO catalogoDao = new CatalogoDAO(txtConnectionString);
            var catalogo = await catalogoDao.GetCatalogoPorCodigo(request.codigoCatalogo);
            if (catalogo == null)
                return 1;
            request.idCatalogo = catalogo.idCatalogo;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await catalogoDao.EliminarCatalogo(request);
        }
    }
}