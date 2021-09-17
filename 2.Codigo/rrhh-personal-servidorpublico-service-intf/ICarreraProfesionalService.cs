using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICarreraProfesionalService
    {
        Task<int> Crear(CarreraProfesionalReplica request);
        Task<int> Actualizar(CarreraProfesionalReplica request);
        Task<int> Eliminar(CarreraProfesionalReplica request);
    }
}