using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICentroTrabajoService
    {
        Task<int> Crear(CentroTrabajoReplica request);
        Task<int> Actualizar(CentroTrabajoReplica request);
        Task<int> Eliminar(CentroTrabajoReplica request);
    }
}