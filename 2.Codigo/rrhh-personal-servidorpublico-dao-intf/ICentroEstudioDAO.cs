using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICentroEstudioDAO
    {
        Task<int> GetIdCentroEstudioPorCodigo(int codigoCentroEstudio);
        Task<int> Crear(CentroEstudioReplica request);
        Task<int> Actualizar(CentroEstudioReplica request);
        Task<int> Eliminar(CentroEstudioReplica request);
    }
}