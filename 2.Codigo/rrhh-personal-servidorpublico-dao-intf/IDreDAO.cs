using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IDreDAO
    {
        Task<int> GetValidarDreId(int idDre,bool activo);
        Task<int> GetIdDrePorCodigo(string codigoDre, bool activo);
        
        Task<int> Crear(DreReplica request);
        Task<int> Actualizar(DreReplica request);
        Task<int> Eliminar(DreReplica request);
    }
}