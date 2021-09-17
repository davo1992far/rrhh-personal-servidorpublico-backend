namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class CentroTrabajoReplica : Auditoria
    {
        public int idCentroTrabajo { get; set; }
        public int? idTipoCentroTrabajo { get; set; }
        public string codigoTipoCentroTrabajo { get; set; }
        public int? idOtraInstancia { get; set; }
        public string codigoOtraInstancia { get; set; }
        public int? idDre { get; set; }
        public string codigoDre { get; set; }
        public int? idUgel { get; set; }
        public string codigoUgel { get; set; }
        public int? idInstitucionEducativa { get; set; }
        public string codigoCentroTrabajo { get; set; }
        public string codigoModular { get; set; }
        public string anexoCentroTrabajo { get; set; }
    }
}