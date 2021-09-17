namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Afp : Auditoria
    {
        public int idAfp { get; set; }
        public int idRegimenPensionario { get; set; }
        public string codigoAfp { get; set; }
        public string descripcionAfp { get; set; }
        public string abreviaturaAfpSunat { get; set; }
    }
}
