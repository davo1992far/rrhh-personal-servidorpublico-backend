using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IAfpService
    {
        Task<int> Crear(AfpReplica request);
        Task<int> Actualizar(AfpReplica request);
        Task<int> Eliminar(AfpReplica request);
    }
}