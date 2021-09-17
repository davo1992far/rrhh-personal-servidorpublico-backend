namespace minedu.rrhh.personal.servidorpublico.model.replica
{
    public class CarreraProfesionalReplica : Auditoria
    {
        public int idCarreraProfesional { get; set; }
        public int? idGrupoCarrera { get; set; }
        public int? codigoGrupoCarrera { get; set; }
        public int codigoCarreraProfesional { get; set; }
        public string descripcionCarreraProfesional { get; set; }
    }
}