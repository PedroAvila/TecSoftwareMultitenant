namespace TecSoftware.EntidadesDominio
{
    public class AlmacenDto
    {
        public int AlmacenId { get; set; }
        public int EstablecimientoId { get; set; }
        public string Nombre { get; set; } //Almacen 01, Almacen 02
        public AlmacenStatus Estado { get; set; }
    }
}
