namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class GradoInstruccionReplica : Auditoria
    {
        public int idGradoInstruccion { get; set; }
        public int codigoGradoInstruccion { get; set; }
        public string codigoOrigenGradoInstruccion { get; set; }
        public string descripcionGradoInstruccion { get; set; }
        public string abreviaturaGradoInstruccion { get; set; }
        public int orden { get; set; }
    }
}