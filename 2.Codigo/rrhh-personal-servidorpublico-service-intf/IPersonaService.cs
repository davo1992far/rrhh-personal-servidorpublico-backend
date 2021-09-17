using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IPersonaService
    {
        Task<int> Crear(PersonaReplica request);
        Task<int> Actualizar(PersonaReplica request);
        Task<int> Eliminar(PersonaReplica request);
    }
}