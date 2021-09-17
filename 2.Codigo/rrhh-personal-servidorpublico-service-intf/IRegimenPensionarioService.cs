using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IRegimenPensionarioService
    {
        Task<int> Crear(RegimenPensionarioReplica request);
        Task<int> Actualizar(RegimenPensionarioReplica request);
        Task<int> Eliminar(RegimenPensionarioReplica request);
    }
}