using System.Threading.Tasks;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro.rrhh_negocio_comunes_maestros_backend;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IInstitucionEducativaDAO
    {
        Task<int> GetIdInstitucionEducativaPorCodigo(string codigoInstitucionEducativa, string anexoInstitucionEducativa, bool activo);

        Task<int> Crear(InstitucionEducativaReplica request);
        Task<int> Actualizar(InstitucionEducativaReplica request);
        Task<int> Eliminar(InstitucionEducativaReplica request);
    }
}