using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class RegimenLaboral : Auditoria
    {
        public int idRegimenLaboral { get; set; }
        public int codigoRegimenLaboral { get; set; }
        public string descripcionRegimenLaboral { get; set; }
        public string abreviaturaRegimenLaboral { get; set; }
        public bool administrativo { get; set; }
    }
}
