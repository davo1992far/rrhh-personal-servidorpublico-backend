using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.dao.intf
{
    public interface IDepartamentoDAO
    {
        public Task<IEnumerable<Departamento>> GetDepartamentos();
        public Task<int> GetIdDepartamentoByCodigoInei(string codigoDepartamentoInei);
        public Task<int> GetValidarDepartamentoId(int idDepartamento);
        Task<Departamento> GetDepartamentoPorId(int idDepartamento);
        Task<Departamento> GetDepartamentoPorCodigoInei(string codigoDepartamentoInei);
        Task<int> CrearDepartamento(Departamento d);
        Task<int> ActualizarDepartamento(Departamento d);
    }
}
