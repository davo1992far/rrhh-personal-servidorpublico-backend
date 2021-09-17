using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ITipoCentroTrabajoService
    {
        Task<int> CrearReplica(TipoCentroTrabajoReplica request);
        Task<int> ActualizarReplica(TipoCentroTrabajoReplica request);
        Task<int> EliminarReplica(TipoCentroTrabajoReplica request);
    }
}