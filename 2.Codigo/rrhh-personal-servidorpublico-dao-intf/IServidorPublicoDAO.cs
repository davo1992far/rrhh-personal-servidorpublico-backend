using minedu.rrhh.personal.servidorpublico.model;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IServidorPublicoDAO
    {
        Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorId(long idServidorPublico);
        Task<ServidorPublicoReplica> GetServidorPublicoReplicaPorCodigo(long codigoServidorPublico);
        Task<long> CrearServidorPublicoTransaction(ServidorPublicoTransaccionRequest servidorPublico);
        Task<ServidorPublico> CrearServidorPublico(ServidorPublico servidorPublico);
        Task<ServidorPublico> CrearServidorPublico(ServidorPublico servidorPublico, SqlConnection con, SqlTransaction tran);
        Task<long> CrearServidorPublicoReplica(ServidorPublico s, SqlConnection con, SqlTransaction tran);
        Task<int> ActualizarServidorPublicoTransaction(ServidorPublicoTransaccionRequest servidorPublico);
        Task<int> ActualizarServidorPublico(ServidorPublico servidorPublico);
        Task<int> ActualizarServidorPublico(ServidorPublico servidorPublico, SqlConnection con, SqlTransaction tran);
        Task<int> DesactivarServidorPublico(ServidorPublico servidorPublico);
        Task<long> GetIdServidorPublicoReplicaPorCodigo(long codigoServidorPublico);
    }
}
