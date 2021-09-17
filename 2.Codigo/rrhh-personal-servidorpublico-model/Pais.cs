namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Pais : Auditoria
    {
        public int idPais { get; set; }
        public string codigoPais { get; set; }
        public string descripcionPais { get; set; }
        public string abreviaturaPais { get; set; }
    }

    public class PaisReplica : Pais
    {
    }
}
