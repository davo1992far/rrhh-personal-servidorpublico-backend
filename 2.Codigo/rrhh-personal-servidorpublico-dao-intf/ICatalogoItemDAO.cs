using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICatalogoItemDAO
    {
        Task<int> EliminarCatalogoItem(CatalogoItemReplica c);
        Task<int> ActualizarCatalogoItem(CatalogoItemReplica c);
        Task<int> CrearCatalogoItem(CatalogoItemReplica c);
        Task<CatalogoItemReplica> GetCatalogoItemPorcodigo(int codigoCatalogoItem);
        Task<int> GetIdCatalogoItemPorCodigoCatalogo(int codigoCatalogo, int codigoCatalogoItem);
        Task<CatalogoItem> GetCatalogoItemPorId(int idCatalogo, int idCatalogoItem);
        Task<TipoDocumentoIdentidad> GetTipoDocumentoIdentidadByCodigo(int codigoTipoDocumentoIdentidad);
        Task<SituacionLaboral> GetSituacionLaboralByCodigo(int codigoSituacionLaboral);
        Task<CondicionLaboral> GetCondicionLaboralByCodigo(int codigoCondicionLaboral);
    }
}
