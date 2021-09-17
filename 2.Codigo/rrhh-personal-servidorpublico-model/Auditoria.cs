using System;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Auditoria
    {
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
        public bool activo { get; set; } = true;
    }
}