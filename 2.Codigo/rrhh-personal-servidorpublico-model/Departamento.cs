namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Departamento : Auditoria
    {
        public int idDepartamento { get; set; }
        public string codigoDepartamentoInei { get; set; }
        public string codigoDepartamentoReniec { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public bool eliminado { get; set; }
    }

    public class DepartamentoReplica : Departamento
    {
    }
}
