namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class TipoCentroTrabajoReplica: Auditoria
    {
        public int idTipoCentroTrabajo { get; set; }
        public int idNivelInstancia { get; set; }
        public int codigoNivelInstancia { get; set; }
        public bool tieneEstructuraOrganica { get; set; }
        public string codigoTipoCentroTrabajo { get; set; }
        public string descripcionTipoCentroTrabajo { get; set; }
    }
}