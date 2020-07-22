namespace TecSoftware.EntidadesDominio
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public CategoriaStatus Estado { get; set; }
    }
}
