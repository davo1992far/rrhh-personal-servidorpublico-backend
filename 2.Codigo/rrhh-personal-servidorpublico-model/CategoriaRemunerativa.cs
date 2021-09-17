using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class CategoriaRemunerativa : Auditoria
    {
        public int idCategoriaRemunerativa { get; set; }
        public int codigoCategoriaRemunerativa { get; set; }
        public string codigoOrigenCategoriaRemunerativa { get; set; }
        public string descripcionCategoriaRemunerativa { get; set; }
        public string abreviaturaCategoriaRemunerativa { get; set; }
        public int? ordenCategoriaRemunerativa { get; set; }
        public bool esEscala { get; set; }
    }
}
