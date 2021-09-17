using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IGradoInstruccionDAO
    {
        Task<int> GetIdGradoInstruccionPorCodigo(int codigoGradoInstruccion);
        Task<int> Crear(GradoInstruccionReplica request);
        Task<int> Actualizar(GradoInstruccionReplica request);
        Task<int> Eliminar(GradoInstruccionReplica request);
    }
}