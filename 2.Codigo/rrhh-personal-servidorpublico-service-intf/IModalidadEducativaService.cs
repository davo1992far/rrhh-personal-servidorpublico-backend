using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IModalidadEducativaService
    {
        Task<int> CrearReplica(ModalidadEducativaReplica request);
        Task<int> ActualizarReplica(ModalidadEducativaReplica request);
        Task<int> EliminarReplica(ModalidadEducativaReplica request);
    }
}