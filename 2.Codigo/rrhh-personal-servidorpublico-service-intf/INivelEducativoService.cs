using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface INivelEducativoService
    {
        Task<int> CrearReplica(NivelEducativoReplica request);
        Task<int> ActualizarReplica(NivelEducativoReplica request);
        Task<int> EliminarReplica(NivelEducativoReplica request);
    }
}