using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IRegimenPensionarioDAO
    {
        Task<RegimenPensionario> GetRegimenPensionarioPorCodigo(int codigoRegimenPensionario);
        Task<int> Crear(RegimenPensionarioReplica request);
        Task<int> Actualizar(RegimenPensionarioReplica request);
        Task<int> Eliminar(RegimenPensionarioReplica request);
    }
}
