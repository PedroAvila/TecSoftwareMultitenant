namespace TecSoftware.EntidadesDominio
{
    public class Laboratorio
    {
        public int LaboratorioId { get; set; }
        public string Nombre { get; set; }
        public string Representante { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public LaboratorioStatus Estado { get; set; }
    }
}
