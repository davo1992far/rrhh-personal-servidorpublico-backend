using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IFormacionAcademicaDAO
    {
        Task<int> GetIdFormacionAcademicaPorCodigo(int codigoFormacionAcademica);
        Task<int> Crear(FormacionAcademicaReplica request);
        Task<int> Actualizar(FormacionAcademicaReplica request);
        Task<int> Eliminar(FormacionAcademicaReplica request);
    }
}