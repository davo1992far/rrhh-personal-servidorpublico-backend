using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICatalogoDAO
    {
        Task<Catalogo> GetCatalogoPorCodigo(int codigoCatalogo);
        Task<int> CrearCatalogo(Catalogo c);
        Task<int> ActualizarCatalogo(Catalogo c);
        Task<int> EliminarCatalogo(Catalogo c);
    }
}