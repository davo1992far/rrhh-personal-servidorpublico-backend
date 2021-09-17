using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;

namespace minedu.rrhh.personas.service.intf
{
    public interface IDistritoService
    {
        Task<IEnumerable<Distrito>> GetDistritosByIdProvincia(int ididUbigeoDepartamento, int idUbigeoProvincia);
        Task<IEnumerable<Distrito>> GetDistritosByCodigoProvinciaInei(string codigoProvinciaInei);
        Task<Distrito> GetDistritoPorId(int idDistrito);
        Task<Distrito> GetDistritoPorCodigoInei(string codigoDistritoinei);
        Task<int> CrearReplica(DistritoReplica request);
        Task<int> ActualizarReplica(DistritoReplica request);
        Task<int> EliminarReplica(DistritoReplica request);
    }
}
