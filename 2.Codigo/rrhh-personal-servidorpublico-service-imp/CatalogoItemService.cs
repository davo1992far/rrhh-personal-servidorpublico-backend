using System;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.common;
using minedu.rrhh.personal.servidorpublico.dao.imp;
using minedu.rrhh.personal.servidorpublico.dao.intf;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.service.intf;
using minedu.tecnologia.util.lib;
using minedu.tecnologia.util.lib.Exceptions;

namespace minedu.rrhh.personal.servidorpublico.service.imp
{
    public class CatalogoItemService: ServiceBase, ICatalogoItemService
    {
        public CatalogoItemService(string txtConnectionString)
        {
            this.txtConnectionString = txtConnectionString;
        }
        
        public async Task<int> CrearReplica(CatalogoItemReplica request)
        {
            try
            {
                ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(txtConnectionString);
                ICatalogoDAO catalogoDao = new CatalogoDAO(txtConnectionString);

                if (request.codigoCatalogo <= 0)
                    throw new ValidationCustomException(Constante.EX_CATALOGO_NOT_FOUND);
                var catalogo = await catalogoDao.GetCatalogoPorCodigo(request.codigoCatalogo);
                if (catalogo == null)
                    throw new NotFoundCustomException(Constante.EX_CATALOGO_NOT_FOUND);
                request.idCatalogo = catalogo.idCatalogo;

                var catalogoItem = await catalogoItemDAO.GetCatalogoItemPorcodigo(request.codigoCatalogoItem);
                if (catalogoItem == null)
                    return await catalogoItemDAO.CrearCatalogoItem(request);
                request.idCatalogoItem = catalogoItem.idCatalogoItem;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await catalogoItemDAO.ActualizarCatalogoItem(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizarReplica(CatalogoItemReplica request)
        {
            try
            {
                ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(txtConnectionString);
                ICatalogoDAO catalogoDao = new CatalogoDAO(txtConnectionString);

                if (request.codigoCatalogo <= 0)
                    throw new ValidationCustomException(Constante.EX_CATALOGO_NOT_FOUND);
                var catalogo = await catalogoDao.GetCatalogoPorCodigo(request.codigoCatalogo);
                if (catalogo == null)
                    throw new NotFoundCustomException(Constante.EX_CATALOGO_NOT_FOUND);
                request.idCatalogo = catalogo.idCatalogo;

                var catalogoItem = await catalogoItemDAO.GetCatalogoItemPorcodigo(request.codigoCatalogoItem);
                if (catalogoItem == null)
                    return await catalogoItemDAO.CrearCatalogoItem(request);
                request.idCatalogoItem = catalogoItem.idCatalogoItem;
                request.ipModificacion ??= request.ipCreacion;
                request.usuarioModificacion ??= request.usuarioCreacion;
                request.fechaModificacion ??= request.fechaCreacion;
                return await catalogoItemDAO.ActualizarCatalogoItem(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EliminarReplica(CatalogoItemReplica request)
        {
            ICatalogoItemDAO catalogoItemDAO = new CatalogoItemDAO(txtConnectionString);

            var catalogoItem = await catalogoItemDAO.GetCatalogoItemPorcodigo(request.codigoCatalogoItem);
            if (catalogoItem == null)
                return 1;
            request.idCatalogoItem = catalogoItem.idCatalogoItem;
            request.ipModificacion ??= request.ipCreacion;
            request.usuarioModificacion ??= request.usuarioCreacion;
            request.fechaModificacion ??= request.fechaCreacion;
            return await catalogoItemDAO.EliminarCatalogoItem(request);
        }
    }
}