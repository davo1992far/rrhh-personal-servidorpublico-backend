namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class EspecialidadProfesionalReplica:Auditoria
    {
        public int idEspecialidadProfesional { get; set; }
        public int? idCarreraProfesional { get; set; }
        public int? codigoCarreraProfesional { get; set; }
        public int? idGrupoCarrera { get; set; }
        public int? codigoGrupoCarrera { get; set; }
        public int codigoEspecialidadProfesional { get; set; }
        public string descripcionEspecialidadProfesional { get; set; }
    }
}