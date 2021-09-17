using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IUgelService
    {
        Task<int> CrearReplica(UgelReplica request);
        Task<int> ActualizarReplica(UgelReplica request);
        Task<int> EliminarReplica(UgelReplica request);
    }
}