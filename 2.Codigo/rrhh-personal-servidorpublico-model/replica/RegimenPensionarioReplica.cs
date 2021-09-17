namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class RegimenPensionarioReplica : Auditoria
    {
        public int idRegimenPensionario { get; set; }
        public int? codigoTipoRetencionTributaria { get; set; }
        public int? idTipoRetencionTributaria { get; set; }
        public int codigoRegimenPensionario { get; set; }
        public string descripcionRegimenPensionario { get; set; }
    }
}