using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICentroTrabajoDAO
    {
        Task<CentroTrabajo> GetCentroTrabajoPorCodigo(string codigoCentroTrabajo, string anexoCentroTrabajo);
        Task<int> Crear(CentroTrabajoReplica request);
        Task<int> Actualizar(CentroTrabajoReplica request);
        Task<int> Eliminar(CentroTrabajoReplica request);
    }
}