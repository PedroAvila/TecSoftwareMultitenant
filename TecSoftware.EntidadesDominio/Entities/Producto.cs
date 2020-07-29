using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public ProductoType TipoProducto { get; set; }
        public string Codigo { get; set; } //13 dígitos
        public string CodigoBarra { get; set; } //15 dígitos
        public string Nombre { get; set; } //300 digitos
        public int CategoriaId { get; set; }
        public int SubCategoriaId { get; set; }
        public int? MarcaId { get; set; }
        public int MonedaId { get; set; }
        public int MedidaId { get; set; }
        public int PresentacionId { get; set; }
        public int? LaboratorioId { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Lote { get; set; }
        public IncluyeImpuesto IncluyeImpuesto { get; set; }
        public ProductoStatus Estado { get; set; }
        public bool CalculoImportePorRangos { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual Medida Medida { get; set; }
        public virtual Presentacion Presentacion { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }

        public virtual ICollection<TasaImpuesto> TasaImpuestos { get; set; }
        public virtual ICollection<Colour> Colores { get; set; }
        public virtual ICollection<Talla> Tallas { get; set; }
        public virtual ICollection<ProductoPrecio> ProductoPrecios { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }

        public virtual ICollection<ProductoTasaImpuesto> ProductoTasaImpuestos { get; set; }
        public virtual ICollection<ProductoColor> ProductoColores { get; set; }
        public virtual ICollection<ProductoTalla> ProductoTallas { get; set; }
        public virtual ICollection<ProductoProveedor> ProductoProveedores { get; set; }
        public object PrecioBase { get; set; }
    }
}
