namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class CentroEstudioReplica : Auditoria
    {
        public int idCentroEstudio { get; set; }
         public int idPais { get; set; }
         public string codigoPais { get; set; }
        public int? idDepartamento { get; set; }
        public string codigoDepartamento { get; set; }
        public int? idProvincia { get; set; }
        public string codigoProvincia { get; set; }
        public int? idDistrito { get; set; }
        public string codigoDistrito { get; set; }
         public int? idNivelCentroEstudio { get; set; }
         public int? codigoNivelCentroEstudio { get; set; }
         public int codigoCentroEstudio { get; set; }
         public string codigoOrigenCentroEstudio { get; set; }
         public string descripcionCentroEstudio { get; set; }
         public bool eliminado { get; set; }
    }
}