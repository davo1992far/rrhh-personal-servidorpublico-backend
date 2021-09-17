using System;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class FormacionAcademica : Auditoria
    {
        public long idFormacionAcademica { get; set; }
        public long idServidorPublico { get; set; }
        public int idPais { get; set; }
        public int? idGradoInstruccion { get; set; }
        public int? idCentroEstudio { get; set; }
        public int? idGrupoCarrera { get; set; }
        public int? idNivelCarrera { get; set; }
        public int? idSituacionAcademica { get; set; }
        public int? idColegioProfesional { get; set; }
        public int? idDepartamento { get; set; }
        public int? idProvincia { get; set; }
        public int? idDistrito { get; set; }
        public int? idEspecialidadProfesional { get; set; }
        public int? idCarreraProfesional { get; set; }
        public int codigoFormacionAcademica { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string anioInicioEstudios { get; set; }
        public string anioFinEstudios { get; set; }
        public DateTime? fechaExpedicionGradoAcademico { get; set; }
        public string numeroColegiatura { get; set; }
        public DateTime? fechaColegiatura { get; set; }
    }
}
