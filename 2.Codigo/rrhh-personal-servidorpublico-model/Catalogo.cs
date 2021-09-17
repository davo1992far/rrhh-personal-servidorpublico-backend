namespace minedu.rrhh.personal.servidorpublico.model
{
    public class Catalogo : Auditoria
    {
        public int idCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public string descripcionCatalogo { get; set; }
        public bool manteniblePorUsuario { get; set; }
        public bool replicable { get; set; }
        public bool eliminado { get; set; }
    }
}