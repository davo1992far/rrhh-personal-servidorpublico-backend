using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IServidorPublicoService
    {
        Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorId(long idServidorPublico, bool todo, bool formacionAcademica);
        Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorCodigo(long codigoServidorPublico, bool todo = false, bool formacionAcademica = false);
        Task<ServidorPublicoTransaccionRequest> CrearServidorPublicoTransaccion(ServidorPublicoTransaccionRequest request);
        
        Task<int> Crear(ServidorPublicoReplica request);
        Task<int> Actualizar(ServidorPublicoReplica request);
        Task<int> Eliminar(ServidorPublicoReplica request);
    }
}
