using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IPaisService
    {
        public Task<IEnumerable<Pais>> GetPaises();
        Task<Pais> GetPaisPorId(int idPais);
        Task<Pais> GetPaisPorCodigo(string codigoPais);
        Task<int> CrearReplica(PaisReplica request);
        Task<int> ActualizarReplica(PaisReplica request);
        Task<int> EliminarReplica(PaisReplica request);
    }
}
