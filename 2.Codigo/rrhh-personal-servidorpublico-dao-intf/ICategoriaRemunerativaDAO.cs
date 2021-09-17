using minedu.rrhh.personal.servidorpublico.model;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface ICategoriaRemunerativaDAO
    {
        Task<CategoriaRemunerativa> GetCategoriaRemunerativaPorCodigo(int codigoCategoriaRemunerativa);
        Task<int> Crear(CategoriaRemunerativaReplica request);
        Task<int> Actualizar(CategoriaRemunerativaReplica request);
        Task<int> Eliminar(CategoriaRemunerativaReplica request);
    }
}
