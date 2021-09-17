namespace minedu.rrhh.personal.servidorpublico.common
{
    public class Utilitario
    {
        public string RemoverUltimoCaracter(string mensaje)
        {
            mensaje = mensaje.Substring(0, mensaje.Length - 1);
            return mensaje;
        }
    }
}
