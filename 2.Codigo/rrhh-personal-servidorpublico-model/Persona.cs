using System;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Persona : Auditoria
    {
        public int idPersona { get; set; }
        public int idTipoPersona { get; set; }
        public int? idGenero { get; set; }
        public int idTipoDocumentoIdentidad { get; set; }
        public int? idEstadoCivil { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime? ultimaActualizacionReniec { get; set; }
        public DateTime? fechaConsultaReniec { get; set; }
        public string emailLaboral { get; set; }
        public string emailPersonal { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoMovil { get; set; }
    }

    public class PersonaReplica : Persona
    {
        public int codigoTipoPersona { get; set; }
        public int? codigoGenero { get; set; }
        public int codigoTipoDocumentoIdentidad { get; set; }
        public int? codigoEstadoCivil { get; set; }
    }
}
