using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IEspecialidadProfesionalService
    {
        Task<int> Crear(EspecialidadProfesionalReplica request);
        Task<int> Actualizar(EspecialidadProfesionalReplica request);
        Task<int> Eliminar(EspecialidadProfesionalReplica request);
    }
}