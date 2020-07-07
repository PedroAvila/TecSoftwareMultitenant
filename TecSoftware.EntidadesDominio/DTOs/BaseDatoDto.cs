namespace TecSoftware.EntidadesDominio
{
    public class BaseDatoDto
    {
        public int BaseDatoId { get; set; }
        public int ServidorId { get; set; }
        public int BaseDatoOfInquilinoId { get; set; }
        public string Nombre { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string Estado { get; set; }
    }
}
