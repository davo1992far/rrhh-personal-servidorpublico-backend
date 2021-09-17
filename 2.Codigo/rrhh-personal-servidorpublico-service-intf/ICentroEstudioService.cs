using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICentroEstudioService
    {
        Task<int> Crear(CentroEstudioReplica request);
        Task<int> Actualizar(CentroEstudioReplica request);
        Task<int> Eliminar(CentroEstudioReplica request);
    }
}