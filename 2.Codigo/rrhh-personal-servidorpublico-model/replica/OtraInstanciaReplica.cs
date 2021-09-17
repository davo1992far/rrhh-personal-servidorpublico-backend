namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class OtraInstanciaReplica: Auditoria
    {
        public int idOtraInstancia { get; set; }
        public int? idUnidadEjecutora { get; set; }
        public string codigoUnidadEjecutora { get; set; }
        public string codigoOtraInstancia { get; set; }
        public string descripcionOtraInstancia { get; set; }
    }
}