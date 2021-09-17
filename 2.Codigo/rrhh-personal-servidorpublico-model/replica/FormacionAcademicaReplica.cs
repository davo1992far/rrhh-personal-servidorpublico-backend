using System;

namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class FormacionAcademicaReplica : Auditoria
    {
        public long idFormacionAcademica { get; set; }
        public long idServidorPublico { get; set; }
        public long codigoServidorPublico { get; set; }
        public int? idPais { get; set; }
        public string codigoPais { get; set; }
        public int? idGradoInstruccion { get; set; }
        public int? codigoGradoInstruccion { get; set; }
        public int? idCentroEstudio { get; set; }
        public int? codigoCentroEstudio { get; set; }
        public int? idGrupoCarrera { get; set; }
        public int? codigoGrupoCarrera { get; set; }
        public int? idNivelCarrera { get; set; }
        public int? codigoNivelCarrera { get; set; }
        public int? idSituacionAcademica { get; set; }
        public int? codigoSituacionAcademica { get; set; }
        public int? idColegioProfesional { get; set; }
        public int? codigoColegioProfesional { get; set; }
        public int? idDepartamento { get; set; }
        public string codigoDepartamento { get; set; }
        public int? idProvincia { get; set; }
        public string codigoProvincia { get; set; }
        public int? idDistrito { get; set; }
        public string codigoDistrito { get; set; }
        public int? idEspecialidadProfesional { get; set; }
        public int? codigoEspecialidadProfesional { get; set; }
        public int? idCarreraProfesional { get; set; }
        public int? codigoCarreraProfesional { get; set; }
        public int codigoFormacionAcademica { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string anioInicioEstudios { get; set; }
        public string anioFinEstudios { get; set; }
        public DateTime? fechaExpedicionGradoEstudios { get; set; }
        public string numeroColegiatura { get; set; }
        public DateTime? fechaColegiatura { get; set; }
    }
}