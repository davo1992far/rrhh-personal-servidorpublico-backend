namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class UnidadEjecutoraReplica: Auditoria
    {
        public int idUnidadEjecutora { get; set; }
        public int idPliego { get; set; }
        public string codigoUnidadEjecutora { get; set; }
        public int secuenciaUnidadEjecutora { get; set; }
        public string descripcionUnidadEjecutora { get; set; }
    }
}