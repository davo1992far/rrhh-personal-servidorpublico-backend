using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface ICargoService
    {
        Task<int> Crear(CargoReplica request);
        Task<int> Actualizar(CargoReplica request);
        Task<int> Eliminar(CargoReplica request);
    }
}