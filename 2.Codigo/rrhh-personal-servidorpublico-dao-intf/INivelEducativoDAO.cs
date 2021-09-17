using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface INivelEducativoDAO
    {
        Task<int> GetNivelEducativoByCodigo(string codigoNivelEducativo);
        Task<int> CrearReplica(NivelEducativoReplica request);
        Task<int> ActualizarReplica(NivelEducativoReplica request);
        Task<int> EliminarReplica(NivelEducativoReplica request);
    }
}