namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class JornadaLaboralReplica : Auditoria
    {
        public int idJornadaLaboral { get; set; }
        public int? idTipoJornadaLaboral { get; set; }
        public int? codigoTipoJornadaLaboral { get; set; }
        public int codigoJornadaLaboral { get; set; }
        public string codigoOrigenJornadaLaboral { get; set; }
        public string descripcionJornadaLaboral { get; set; }
        public string abreviaturaJornadaLaboral { get; set; }
        public int? ordenJornadaLaboral { get; set; }
        public int? cantidadJornadaLaboral { get; set; }
    }
}