using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IModalidadEducativaDAO
    {
        Task<int> CrearReplica(ModalidadEducativaReplica request);
        Task<int> ActualizarReplica(ModalidadEducativaReplica request);
        Task<int> EliminarReplica(ModalidadEducativaReplica request);
        Task<int> GetModalidadEducativaByCodigo(int codigoModalidadEducativa);
    }
}