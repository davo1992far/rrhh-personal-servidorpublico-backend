using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IDistritoDAO
    {
        public Task<IEnumerable<Distrito>> GetDistritosByIdProvincia(int idDepartamento, int idProvincia);
        Task<Distrito> GetDistritoPorId(int idDistrito);
        Task<Distrito> GetDistritoPorCodigoInei(string codigoDistritoInei);
        Task<int> CrearDistrito(Distrito d);
        Task<int> ActualizarDistrito(Distrito d);
    }
}
