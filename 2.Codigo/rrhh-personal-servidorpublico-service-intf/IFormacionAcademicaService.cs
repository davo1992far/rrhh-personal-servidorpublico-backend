using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IFormacionAcademicaService
    {
        Task<int> Crear(FormacionAcademicaReplica request);
        Task<int> Actualizar(FormacionAcademicaReplica request);
        Task<int> Eliminar(FormacionAcademicaReplica request);
    }
}