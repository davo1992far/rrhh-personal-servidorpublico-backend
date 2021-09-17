using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IUnidadEjecutoraDAO
    {
        Task<int> BuscarUnidadEjecutoraCodigo(string codigoUnidadEjecutora);
        Task<int> Crear(UnidadEjecutoraReplica request);
        Task<int> Actualizar(UnidadEjecutoraReplica request);
        Task<int> Eliminar(UnidadEjecutoraReplica request);
    }
}