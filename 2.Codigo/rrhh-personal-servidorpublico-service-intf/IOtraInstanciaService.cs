using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IOtraInstanciaService
    {
        Task<int> Crear(OtraInstanciaReplica request);
        Task<int> Actualizar(OtraInstanciaReplica request);
        Task<int> Eliminar(OtraInstanciaReplica request);
    }
}