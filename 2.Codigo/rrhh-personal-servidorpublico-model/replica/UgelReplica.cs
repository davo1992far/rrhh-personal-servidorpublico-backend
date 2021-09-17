namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class UgelReplica: Auditoria
    {
        public int idUgel { get; set; }
        public int idUnidadEjecutora { get; set; }
        public int idDre { get; set; }
        public long? idServidorPublicoDirector { get; set; }    
        public int? idDistrito { get; set; }    
        public string codigoDre { get; set; }
        public string codigoUnidadEjecutora { get; set; }
        public string codigoUgel { get; set; }
        public long? codigoServidorPublico { get; set; }
        public string codigoDistrito { get; set; }
        public string descripcionUgel { get; set; }
    }
}