using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IAfpDAO
    {
        Task<Afp> GetAfpPorCodigo(string codigoAfp);
        Task<int> Crear(AfpReplica request);
        Task<int> Actualizar(AfpReplica request);
        Task<int> Eliminar(AfpReplica request);
    }
}
