using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICargoDAO
    {
        Task<Cargo> GetCargoPorCodigo(int codigoCargo);
        Task<int> GetIdCargoPorCodigo(int codigoCargo, bool activo);
        Task<int> Crear(CargoReplica request);
        Task<int> Actualizar(CargoReplica request);
        Task<int> Eliminar(CargoReplica request);
    }
}
