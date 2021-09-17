using minedu.rrhh.personal.servidorpublico.model;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IPersonaDAO
    {
        Task<Persona> GetPersonaPorId(int idPersona);
        Task<Persona> GetPersonaPorDocumentoIdentidad(int idTipoDocumentoIdentidad, string numeroDocumentoIdentidad);
        Task<PersonaReplica> GetPersonaReplicaPorId(int idPersona);
        Task<PersonaReplica> GetPersonaReplicaPorDocumento(int idTipoDocumentoIdentidad, string numeroDocumentoIdentidad);
        
        Task<int> Crear(PersonaReplica request);
        Task<int> Actualizar(PersonaReplica request);
        Task<int> Eliminar(PersonaReplica request);
    }
}
