namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class ModalidadEducativaReplica:Auditoria
    {
        public int idModalidadEducativa { get; set; }
        public int codigoModalidadEducativa { get; set; }
        public string descripcionModalidadEducativa { get; set; }
        public string abreviaturaModalidadEducativa { get; set; }
        public int? orden { get; set; }
    }
}