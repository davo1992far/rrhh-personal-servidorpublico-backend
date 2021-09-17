using System;

namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class RegimenLaboralReplica : Auditoria
    {
        public int idRegimenLaboral { get; set; }
        public int? idTipoRetencionTributaria { get; set; }
        public int? codigoTipoRetencionTributaria { get; set; }
        public int codigoRegimenLaboral { get; set; }
        public string descripcionRegimenLaboral { get; set; }
        public string abreviaturaRegimenLaboral { get; set; }
        public bool administrativo { get; set; }
        public DateTime fechaInicioVigencia { get; set; }
        public DateTime? fechaFinVigencia { get; set; }
    }
}