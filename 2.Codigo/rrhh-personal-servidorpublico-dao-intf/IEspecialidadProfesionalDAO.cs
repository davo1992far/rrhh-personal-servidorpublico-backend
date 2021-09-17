using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IEspecialidadProfesionalDAO
    {
        Task<int> GetIdEspecialidadProfesionalPorCodigo(int codigoEspecialidadProfesional);
        Task<int> Crear(EspecialidadProfesionalReplica request);
        Task<int> Actualizar(EspecialidadProfesionalReplica request);
        Task<int> Eliminar(EspecialidadProfesionalReplica request);
    }
}