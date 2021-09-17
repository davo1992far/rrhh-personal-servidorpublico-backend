using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class ServidorPublico : Auditoria
    {
        public long idServidorPublico { get; set; }
        public int idPersona { get; set; }
        public int idRegimenLaboral { get; set; }
        public int idSituacionLaboral { get; set; }
        public int idCondicionLaboral { get; set; }
        public int? idAfp { get; set; }
        public int? idRegimenPensionario { get; set; }
        public int? idCargo { get; set; }
        public int? idJornadaLaboral { get; set; }
        public int? idCategoriaRemunerativa { get; set; }
        public int? idTipoComisionAfp { get; set; }
        public int? idCentroTrabajo { get; set; }
        public long codigoServidorPublico { get; set; }
        public string codigoPlaza { get; set; }
        public string cuspp { get; set; }
        public DateTime? fechaIngresoSpp { get; set; }
        public DateTime? fechaInicioVinculacion { get; set; }
        public DateTime? fechaFinVinculacion { get; set; }
        public DateTime? fechaCese { get; set; }
        public IEnumerable<FormacionAcademica> formacionesAcademicas { get; set; }
    }

    public class ServidorPublicoReplica : ServidorPublico
    {
        public int codigoTipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public int codigoRegimenLaboral { get; set; }
        public string descripcionRegimenLaboral { get; set; }
        public int codigoSituacionLaboral { get; set; }
        public int codigoCondicionLaboral { get; set; }
        public string codigoAfp { get; set; }
        public string descripcionAfp { get; set; }
        public int? codigoRegimenPensionario { get; set; }
        public string descripcionRegimenPensionario { get; set; }
        public int? codigoCargo { get; set; }
        public string descripcionCargo { get; set; }
        public int? codigoJornadaLaboral { get; set; }
        public int? codigoTipoComisionAfp { get; set; }
        public string descripcionJornadaLaboral { get; set; }
        public int? codigoCategoriaRemunerativa { get; set; }
        public string descripcionCategoriaRemunerativa { get; set; }
        public string codigoCentroTrabajo { get; set; }
        public string anexoCentroTrabajo { get; set; }
        public string descripcionCentroTrabajo { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public DateTime? fechaConsultaReniec { get; set; }
    }

    public class ServidorPublicoTransaction : Auditoria
    {
        public long idServidorPublico { get; set; }
        public long codigoServidorPublico { get; set; }
        public string codigoPlaza { get; set; }
        public int?  idPlaza { get; set; }
        public int? idCategoriaRemunerativa { get; set; }
        public int idRegimenLaboral { get; set; }
        public int idSituacionLaboral { get; set; }
        public int idCondicionLaboral { get; set; }
        public int idPersona { get; set; }
        public int codigoTipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public int codigoRegimenLaboral { get; set; }
        public int codigoSituacionLaboral { get; set; }
        public int codigoCondicionLaboral { get; set; }
        public int? codigoCategoriaRemunerativa { get; set; }
        public string codigoCentroTrabajo { get; set; }
        public string anexoCentroTrabajo { get; set; }
        public int? idCentroTrabajo { get; set; }
        public DateTime? fechaCese { get; set; }
        public DateTime? fechaInicio { get; set; }
    }
    
    
    public class ServidorPublicoTransaccionRequest : ServidorPublicoTransaction
    {
        public Guid codigoResolucion { get; set; }
    }
}
