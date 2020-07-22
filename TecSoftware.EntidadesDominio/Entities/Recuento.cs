namespace TecSoftware.EntidadesDominio
{
    public class Recuento
    {
        public int RecuentoId { get; set; }
        public int OperacionId { get; set; }
        public int DenominacionId { get; set; }
        public decimal Cantidad { get; set; }

        public virtual Operacion Operacion { get; set; }
        public virtual Denominacion Denominacion { get; set; }
    }
}