using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IProvinciaDAO
    {
        public Task<IEnumerable<Provincia>> GetProvinciasByIdDepartamento(int idDepartamento);
        public Task<int> GetValidarProvinciaId(int idDepartamento, int idProvincia);
        public Task<Provincia> GetProvinciaPorId(int idProvincia);
        public Task<Provincia> GetProvinciaPorCodigoInei(string codigoProvinciaInei);
        public Task<Provincia> GetIdProvinciaByCodigoInei(string codigoProvinciaInei);
        Task<int> CrearProvincia(Provincia d);
        Task<int> ActualizarProvincia(Provincia d);
    }
}
