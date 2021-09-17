namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class CategoriaRemunerativaReplica: Auditoria
    {
        public int idCategoriaRemunerativa { get; set; }
        public int codigoCategoriaRemunerativa { get; set; }
        public string codigoOrigenCategoriaRemunerativa { get; set; }
        public string descripcionCategoriaRemunerativa { get; set; }
        public string abreviaturaCategoriaRemunerativa { get; set; }
        public int ordenCategoriaRemunerativa { get; set; }
        public int esEscala { get; set; }
    }
}