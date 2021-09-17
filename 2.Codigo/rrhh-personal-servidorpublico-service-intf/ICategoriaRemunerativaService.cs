using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICategoriaRemunerativaService
    {
        Task<int> Crear(CategoriaRemunerativaReplica request);
        Task<int> Actualizar(CategoriaRemunerativaReplica request);
        Task<int> Eliminar(CategoriaRemunerativaReplica request);
    }
}