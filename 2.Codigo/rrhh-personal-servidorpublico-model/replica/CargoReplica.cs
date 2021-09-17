namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class CargoReplica: Auditoria
    { 
        public int idCargo { get; set; }
        public int idRegimenLaboral { get; set; }
        public int CodigoRegimenLaboral { get; set; }
        public int codigoCargo { get; set; }
        public string descripcionCargo { get; set; }
        public string abreviaturaCargo { get; set; }
    }
}