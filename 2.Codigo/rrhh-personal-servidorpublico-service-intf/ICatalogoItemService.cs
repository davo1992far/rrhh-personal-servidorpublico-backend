using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICatalogoItemService
    {
        Task<int> CrearReplica(CatalogoItemReplica request);
        Task<int> ActualizarReplica(CatalogoItemReplica request);
        Task<int> EliminarReplica(CatalogoItemReplica request);
    }
}