using System;

namespace TecSoftware.EntidadesDominio
{
    public class MovimientoInventario
    {
        public int MovimientoInventarioId { get; set; }
        public int ProductoAlmacenId { get; set; }
        public int ProductoOperacionMovimientoId { get; set; }
        public int ProductoRegistroInventarioId { get; set; }
        public DateTime FechaOperacionInventario { get; set; }
        public decimal CantidadSaldoInicial { get; set; }
        public decimal CostoUnitarioSaldoInicial { get; set; }
        public decimal CostoTotalSaldoInical { get; set; }
        public decimal CantidadEntrada { get; set; }
        public decimal CostoUnitarioEntrada { get; set; }
        public decimal CostoTotalEntrada { get; set; }
        public decimal CantidadSalida { get; set; }
        public decimal CostoUnitarioSalida { get; set; }
        public decimal CostoTotalSalida { get; set; }
        public decimal CantidadSaldoFinal { get; set; }
        public decimal CostoUnitarioSaldoFinal { get; set; }
        public decimal CostoTotalSaldoFinal { get; set; }

        public virtual ProductoAlmacen ProductoAlmacen { get; set; }
        public virtual ProductoOperacionMovimiento ProductoOperacionMovimiento { get; set; }
        public virtual ProductoRegistroInventario ProductoRegistroInventario { get; set; }
    }
}
