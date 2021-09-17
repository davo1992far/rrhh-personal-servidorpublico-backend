using System.Collections.Generic;
using System.Threading.Tasks;
using minedu.rrhh.personal.servidorpublico.model;
using minedu.rrhh.personal.servidorpublico.model.replica;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IRegimenLaboralService
    {
        Task<int> CrearReplica(RegimenLaboralReplica request);
        Task<int> ActualizarReplica(RegimenLaboralReplica request);
        Task<int> EliminarReplica(RegimenLaboralReplica request);
    }
}