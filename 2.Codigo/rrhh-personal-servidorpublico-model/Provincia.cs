namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Provincia : Auditoria
    {
        public int idProvincia { get; set; }
        public int idDepartamento { get; set; }
        public string codigoProvinciaInei { get; set; }
        public string codigoProvinciaReniec { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public bool eliminado { get; set; }
    }

    public class ProvinciaReplica : Provincia
    {
        public string codigoDepartamentoInei { get; set; }
    }
}
