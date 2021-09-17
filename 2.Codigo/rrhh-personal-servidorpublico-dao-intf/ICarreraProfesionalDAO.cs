using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICarreraProfesionalDAO
    {
        Task<int> GetIdCarreraProfesionalPorCodigo(int codigoCarreraProfesional);
        Task<int> Crear(CarreraProfesionalReplica request);
        Task<int> Actualizar(CarreraProfesionalReplica request);
        Task<int> Eliminar(CarreraProfesionalReplica request);
    }
}