using System;
using System.Collections.Generic;
using System.Text;

namespace minedu.rrhh.personal.servidorpublico.model
{
    public class CentroTrabajo : Auditoria
    {
        public int idCentroTrabajo { get; set; }
        public int idTipoCentroTrabajo { get; set; }
        public int? idOtraInstancia { get; set; }
        public int? idDre { get; set; }
        public int? idUgel { get; set; }
        public int? idInstitucionEducativa { get; set; }
        public string codigoCentroTrabajo { get; set; }
        public string anexoCentroTrabajo { get; set; }
    }
}
