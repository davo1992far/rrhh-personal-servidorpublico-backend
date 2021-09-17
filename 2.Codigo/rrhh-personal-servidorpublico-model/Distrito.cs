namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Distrito : Auditoria
    {
        public int idDistrito { get; set; }
        public int idDepartamento { get; set; }
        public int idProvincia { get; set; }
        public string codigoDistritoInei { get; set; }
        public string codigoDistritoReniec { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public bool eliminado { get; set; }
    }

    public class DistritoReplica : Distrito
    {
        public string codigoDepartamentoInei { get; set; }
        public string codigoProvinciaInei { get; set; }
    }
}
