namespace minedu.rrhh.personal.servidorpublico.model
{
    public class InstitucionEducativa
    {
        public int idInstitucionEducativa { get; set; }
        public int idDistrito { get; set; }
        public int? idUgel { get; set; }
        public string codigoModular { get; set; }
        public string descripcionInstitucionEducativa { get; set; }
        public string abreviaturaInstitucionEducativa { get; set; }
    }
    
    
}