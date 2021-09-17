using minedu.rrhh.personal.servidorpublico.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.service.intf
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> GetDepartamentos();
        Task<Departamento> GetDepartamentoPorId(int idDepartamento);
        Task<Departamento> GetDepartamentoPorCodigoInei(string codigoDepartamentoInei);
        Task<int> CrearReplica(DepartamentoReplica request);
        Task<int> ActualizarReplica(DepartamentoReplica request);
        Task<int> EliminarReplica(DepartamentoReplica request);
    }
}
