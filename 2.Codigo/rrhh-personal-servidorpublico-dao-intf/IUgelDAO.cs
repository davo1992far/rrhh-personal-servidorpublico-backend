using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IUgelDAO
    {
        Task<int> GetIdUgelPorCodigo(string codigoUgel, bool activo);
        Task<int> Crear(UgelReplica request);
        Task<int> Actualizar(UgelReplica request);
        Task<int> Eliminar(UgelReplica request);
    }
}