namespace minedu.rrhh.personal.servidorpublico.model
{
    public class CatalogoItem : Auditoria
    {
        public int idCatalogoItem { get; set; }
        public int codigoCatalogoItem { get; set; }
        public string abreviaturaCatalogoItem { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public bool eliminado { get; set; }
    }
    public class CatalogoItemReplica : Auditoria
    {
        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public int codigoCatalogoItem { get; set; }
        public int? orden { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string abreviaturaCatalogoItem { get; set; }
        public bool eliminado { get; set; }
    }
    public class TipoDocumentoIdentidad
    {
        public int idTipoDocumentoIdentidad { get; set; }
        public int codigoTipoDocumentoIdentidad { get; set; }
    }
    public class EstadoCivil
    {
        public int idEstadoCivil { get; set; }
        public int codigoEstadoCivil { get; set; }
    }
    public class Genero
    {
        public int idGenero { get; set; }
        public int codigoGenero { get; set; }
    }
    public class TipoVia
    {
        public int idTipoVia { get; set; }
        public int codigoTipoVia { get; set; }
    }
    public class TipoZona
    {
        public int idTipoZona { get; set; }
        public int codigoTipoZona { get; set; }
    }
    public class SituacionLaboral
    {
        public int idSituacionLaboral { get; set; }
        public int codigoSituacionLaboral { get; set; }
    }
    public class CondicionLaboral
    {
        public int idCondicionLaboral { get; set; }
        public int codigoCondicionLaboral { get; set; }
    }
}
