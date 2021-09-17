using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IJornadaLaboralService
    {
        Task<int> Crear(JornadaLaboralReplica request);
        Task<int> Actualizar(JornadaLaboralReplica request);
        Task<int> Eliminar(JornadaLaboralReplica request);
    }
}