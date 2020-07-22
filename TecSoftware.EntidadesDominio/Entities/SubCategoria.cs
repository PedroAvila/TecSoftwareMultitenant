namespace TecSoftware.EntidadesDominio
{
    public class SubCategoria
    {
        public int SubCategoriaId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public SubCategoriaStatus Estado { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
