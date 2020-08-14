using System;

namespace TecSoftware.EntidadesDominio
{
    public class CierreCajaExtend
    {
        public string NombreEstablecimiento { get; set; }
        public string NombrePuntoEmision { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public string NombreUsuario { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Egreso { get; set; }
        public decimal Saldo { get; set; }
        public decimal MontoInicialSaldo { get; set; }
    }
}
