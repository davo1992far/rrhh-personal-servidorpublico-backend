using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ITipoCentroTrabajoDAO
    {
        Task<int> GetIdTipoCentroTrabajoPorCodigo(string codigoTipoCentroTrabajo, bool activo);
        Task<int> Crear(TipoCentroTrabajoReplica request);
        Task<int> Actualizar(TipoCentroTrabajoReplica request);
        Task<int> Eliminar(TipoCentroTrabajoReplica request);
    }
}