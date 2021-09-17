namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class DreReplica: Auditoria
    {
        public int idDre { get; set; }

        public string codigoUnidadEjecutora { get; set; }
        public int idUnidadEjecutora { get; set; }
        public long? idServidorPublicoDirector { get; set; }    
        public int? idDistrito { get; set; }    
        public string descripcionDre { get; set; }
        public long? codigoServidorPublico { get; set; }
        public string codigoDistrito { get; set; }
        public string codigoDre { get; set; }
    }
}