namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Cargo : Auditoria
    {
        public int idCargo { get; set; }
        public int idRegimenLaboral { get; set; }
        public int codigoCargo { get; set; }
        public string descripcionCargo { get; set; }
        public string abreviaturaCargo { get; set; }
    }
}
