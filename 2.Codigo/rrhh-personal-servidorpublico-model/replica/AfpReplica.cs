namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class AfpReplica : Auditoria
    {
        public int idAfp { get; set; }
        public int idRegimenPensionario { get; set; }
        public int codigoRegimenPensionario { get; set; }
        public string codigoAfp { get; set; }
        public string descripcionAfp { get; set; }
        public string abreviaturaAfpSunat { get; set; }
    }
}