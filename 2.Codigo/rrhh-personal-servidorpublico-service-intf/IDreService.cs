using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IDreService
    {
        Task<int> CrearReplica(DreReplica request);
        Task<int> ActualizarReplica(DreReplica request);
        Task<int> EliminarReplica(DreReplica request);
    }
}