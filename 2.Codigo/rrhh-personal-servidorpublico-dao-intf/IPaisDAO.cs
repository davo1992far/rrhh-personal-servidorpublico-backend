using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IPaisDAO
    {
        public Task<IEnumerable<Pais>> GetPaises();
        Task<Pais> GetPaisPorId(int idPais);
        Task<Pais> GetPaisPorCodigo(string codigoPais);
        Task<int> GetIdPaisPorCodigo(string codigoPais);
        Task<int> CrearPais(Pais p);
        Task<int> ActualizarPais(Pais p);
    }
}
