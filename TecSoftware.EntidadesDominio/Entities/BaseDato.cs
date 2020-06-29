namespace TecSoftware.EntidadesDominio
{
    public class BaseDato
    {
        public int BaseDatoId { get; set; }
        public int ServidorId { get; set; }
        public int BaseDatoOfInquilinoId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual Servidor Servidor { get; set; }
        public virtual Inquilino Inquilino { get; set; }
    }
}
