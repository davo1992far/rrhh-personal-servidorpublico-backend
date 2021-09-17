using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IUnidadEjecutoraService
    {
        Task<int> Crear(UnidadEjecutoraReplica request);
        Task<int> Actualizar(UnidadEjecutoraReplica request);
        Task<int> Eliminar(UnidadEjecutoraReplica request);
    }
}