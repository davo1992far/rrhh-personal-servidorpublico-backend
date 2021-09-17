using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class JornadaLaboral : Auditoria
    {
        public int idJornadaLaboral { get; set; }
        public int? idTipoJornadaLaboral { get; set; }
        public int codigoJornadaLaboral { get; set; }
        public string codigoOrigenJornadaLaboral { get; set; }
        public string descripcionJornadaLaboral { get; set; }
        public string abreviaturaJornadaLaboral { get; set; }
        public int? ordenJornadaLaboral { get; set; }
        public int? cantidadJornadaLaboral { get; set; }
    }
}
