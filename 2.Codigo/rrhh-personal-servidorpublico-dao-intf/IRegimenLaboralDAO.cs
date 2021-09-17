using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IRegimenLaboralDAO
    {
        Task<RegimenLaboral> GetRegimenLaboralPorCodigo(int codigoRegimenLaboral);
        Task<int> Crear(RegimenLaboralReplica request);
        Task<int> Actualizar(RegimenLaboralReplica request);
        Task<int> Eliminar(RegimenLaboralReplica request);
    }
}
