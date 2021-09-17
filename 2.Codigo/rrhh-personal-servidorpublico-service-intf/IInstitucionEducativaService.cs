using System.Threading.Tasks;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.ReplicaRegistro.rrhh_negocio_comunes_maestros_backend;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IInstitucionEducativaService
    {
        Task<int> CrearReplica(InstitucionEducativaReplica request);
        Task<int> ActualizarReplica(InstitucionEducativaReplica request);
        Task<int> EliminarReplica(InstitucionEducativaReplica request);
    }
}