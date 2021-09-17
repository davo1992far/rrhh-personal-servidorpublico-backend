using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IGradoInstruccionService
    {
        Task<int> Crear(GradoInstruccionReplica request);
        Task<int> Actualizar(GradoInstruccionReplica request);
        Task<int> Eliminar(GradoInstruccionReplica request);
    }
}