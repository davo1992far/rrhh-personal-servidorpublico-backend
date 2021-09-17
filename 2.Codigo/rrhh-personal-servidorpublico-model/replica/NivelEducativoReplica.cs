namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class NivelEducativoReplica:Auditoria
    {
        public int idNivelEducativo { get; set; }
        public int? idModalidadEducativa { get; set; }
        public int? codigoModalidadEducativa { get; set; }
        public string codigoNivelEducativo { get; set; }
        public string descripcionNivelEducativo { get; set; }
        public string abreviaturaNivelEducativo { get; set; }
        public int? orden { get; set; }
    }
}