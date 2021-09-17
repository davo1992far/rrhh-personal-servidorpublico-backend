using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IOtraInstanciaDAO
    {
        Task<int> GetIdOtraInstanciaPorCodigo(string codigoOtraEntidad, bool activo);
        Task<int> Crear(OtraInstanciaReplica request);
        Task<int> Actualizar(OtraInstanciaReplica request);
        Task<int> Eliminar(OtraInstanciaReplica request);
    }
}