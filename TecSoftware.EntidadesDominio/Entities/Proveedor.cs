using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string Numero { get; set; }
        public string RazonSocial { get; set; }
        public string Representante { get; set; }
        public int UbigeoId { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EmailProveedor { get; set; }
        public string EmailVendedor { get; set; }
        public ProveedorStatus Estado { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual Ubigeo Ubigeo { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}