using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class RegimenPensionario : Auditoria
    {
        public int idRegimenPensionario { get; set; }
        public int codigoRegimenPensionario { get; set; }
        public string descripcionRegimenPensionario { get; set; }
    }
}
