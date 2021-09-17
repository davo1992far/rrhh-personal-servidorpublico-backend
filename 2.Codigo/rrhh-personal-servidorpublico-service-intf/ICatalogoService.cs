using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICatalogoService
    {
        Task<int> CrearReplica(Catalogo request);
        Task<int> ActualizarReplica(Catalogo request);
        Task<int> EliminarReplica(Catalogo request);
    }
}