using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IProvinciaService
    {
        Task<IEnumerable<Provincia>> GetProvinciasByIdDepartamento(int idUbigeoDepartamento);
        Task<IEnumerable<Provincia>> GetProvinciasByCodigoDepartamentoInei(string codigoDepartamentoInei);
        Task<Provincia> GetProvinciaPorId(int idProvincia);
        Task<Provincia> GetProvinciaPorCodigoInei(string codigoProvinciaInei);
        Task<int> CrearReplica(ProvinciaReplica request);
        Task<int> ActualizarReplica(ProvinciaReplica request);
        Task<int> EliminarReplica(ProvinciaReplica request);
    }
}
