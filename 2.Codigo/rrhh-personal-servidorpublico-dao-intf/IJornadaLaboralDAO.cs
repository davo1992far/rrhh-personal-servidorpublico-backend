using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IJornadaLaboralDAO
    {
        Task<JornadaLaboral> GetJornadaLaboralPorCodigo(int codigoJornadaLaboral);
        Task<int> Crear(JornadaLaboralReplica request);
        Task<int> Actualizar(JornadaLaboralReplica request);
        Task<int> Eliminar(JornadaLaboralReplica request);
    }
}
