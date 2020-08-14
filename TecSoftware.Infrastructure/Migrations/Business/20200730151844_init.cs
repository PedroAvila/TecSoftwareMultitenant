using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecSoftware.Infrastructure.Migrations.Business
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaNegocios",
                columns: table => new
                {
                    AreaNegocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaNegocios", x => x.AreaNegocioId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    ComprobanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 2, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.ComprobanteId);
                });

            migrationBuilder.CreateTable(
                name: "ConceptoInventarios",
                columns: table => new
                {
                    ConceptoInventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    TipoOperacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptoInventarios", x => x.ConceptoInventarioId);
                });

            migrationBuilder.CreateTable(
                name: "Denominaciones",
                columns: table => new
                {
                    DenominacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denominaciones", x => x.DenominacionId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruc = table.Column<string>(maxLength: 13, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 300, nullable: true),
                    Direccion = table.Column<string>(maxLength: 300, nullable: true),
                    TelefonoFijo = table.Column<string>(maxLength: 10, nullable: true),
                    TelefonoCelular = table.Column<string>(maxLength: 10, nullable: true),
                    Representante = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    ClaveEmail = table.Column<string>(maxLength: 30, nullable: true),
                    ObligadoContabilidad = table.Column<int>(nullable: false),
                    Emision = table.Column<int>(nullable: false),
                    Ambiente = table.Column<int>(nullable: false),
                    LogoEmisor = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoComprobanteElectronicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Siglas = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoComprobanteElectronicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagos",
                columns: table => new
                {
                    FormaPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: true),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagos", x => x.FormaPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                });

            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    ImpuestoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: true),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuestos", x => x.ImpuestoId);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Representante = table.Column<string>(maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.LaboratorioId);
                });

            migrationBuilder.CreateTable(
                name: "ListaPrecios",
                columns: table => new
                {
                    ListaPrecioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecios", x => x.ListaPrecioId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    MedidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 60, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.MedidaId);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    MonedaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.MonedaId);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientoCompras",
                columns: table => new
                {
                    RequerimientoCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroRequerimiento = table.Column<string>(maxLength: 10, nullable: true),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientoCompras", x => x.RequerimientoCompraId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Tallas",
                columns: table => new
                {
                    TallaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallas", x => x.TallaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificaciones",
                columns: table => new
                {
                    TipoIdentificacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 2, nullable: true),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificaciones", x => x.TipoIdentificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeos",
                columns: table => new
                {
                    UbigeoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProvincia = table.Column<string>(maxLength: 2, nullable: true),
                    Provincia = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoCanton = table.Column<string>(maxLength: 4, nullable: true),
                    Canton = table.Column<string>(maxLength: 100, nullable: true),
                    CodigoParroquia = table.Column<string>(maxLength: 6, nullable: true),
                    Parroquia = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeos", x => x.UbigeoId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorias",
                columns: table => new
                {
                    SubCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorias", x => x.SubCategoriaId);
                    table.ForeignKey(
                        name: "FK_SubCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Establecimientos",
                columns: table => new
                {
                    EstablecimientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 3, nullable: true),
                    Nombre = table.Column<string>(maxLength: 120, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    TelefonoFijo = table.Column<string>(maxLength: 10, nullable: true),
                    TelefonoCelular = table.Column<string>(maxLength: 10, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimientos", x => x.EstablecimientoId);
                    table.ForeignKey(
                        name: "FK_Establecimientos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TasaImpuestos",
                columns: table => new
                {
                    TasaImpuestoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpuestoId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Concepto = table.Column<string>(maxLength: 500, nullable: true),
                    Tasa = table.Column<decimal>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaImpuestos", x => x.TasaImpuestoId);
                    table.ForeignKey(
                        name: "FK_TasaImpuestos_Impuestos_ImpuestoId",
                        column: x => x.ImpuestoId,
                        principalTable: "Impuestos",
                        principalColumn: "ImpuestoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    PresentacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedidaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Abreviacion = table.Column<string>(maxLength: 50, nullable: true),
                    Equivalencia = table.Column<decimal>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => x.PresentacionId);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolFuncion",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false),
                    FuncionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolFuncion", x => new { x.RolId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_RolFuncion_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolFuncion_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    User = table.Column<string>(maxLength: 15, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacionId = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(maxLength: 20, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 300, nullable: true),
                    Direccion = table.Column<string>(maxLength: 300, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoIdentificaciones_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificaciones",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteTipoIdentificacion",
                columns: table => new
                {
                    ComprobanteId = table.Column<int>(nullable: false),
                    TipoIdentificacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteTipoIdentificacion", x => new { x.ComprobanteId, x.TipoIdentificacionId });
                    table.ForeignKey(
                        name: "FK_ComprobanteTipoIdentificacion_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ComprobanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprobanteTipoIdentificacion_TipoIdentificaciones_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificaciones",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacionId = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(maxLength: 18, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 100, nullable: true),
                    Representante = table.Column<string>(maxLength: 100, nullable: true),
                    UbigeoId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    EmailProveedor = table.Column<string>(maxLength: 80, nullable: true),
                    EmailVendedor = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedores_TipoIdentificaciones_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificaciones",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedores_Ubigeos_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeos",
                        principalColumn: "UbigeoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Almacenes",
                columns: table => new
                {
                    AlmacenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablecimientoId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenes", x => x.AlmacenId);
                    table.ForeignKey(
                        name: "FK_Almacenes_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "EstablecimientoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuntoEmisiones",
                columns: table => new
                {
                    PuntoEmisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablecimientoId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 3, nullable: true),
                    Nombre = table.Column<string>(maxLength: 120, nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoEmisiones", x => x.PuntoEmisionId);
                    table.ForeignKey(
                        name: "FK_PuntoEmisiones_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "EstablecimientoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProducto = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 13, nullable: true),
                    CodigoBarra = table.Column<string>(maxLength: 15, nullable: true),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    SubCategoriaId = table.Column<int>(nullable: false),
                    MarcaId = table.Column<int>(nullable: true),
                    MonedaId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    LaboratorioId = table.Column<int>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: true),
                    PrecioCompra = table.Column<decimal>(nullable: false),
                    Lote = table.Column<string>(maxLength: 10, nullable: true),
                    IncluyeImpuesto = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    CalculoImportePorRangos = table.Column<bool>(nullable: false),
                    PrecioBase = table.Column<decimal>(nullable: false),
                    TallaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Laboratorios_LaboratorioId",
                        column: x => x.LaboratorioId,
                        principalTable: "Laboratorios",
                        principalColumn: "LaboratorioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Monedas_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Monedas",
                        principalColumn: "MonedaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_SubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "SubCategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Tallas_TallaId",
                        column: x => x.TallaId,
                        principalTable: "Tallas",
                        principalColumn: "TallaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenInventarios",
                columns: table => new
                {
                    OrdenInventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroOrden = table.Column<string>(maxLength: 10, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    EstadoOrden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenInventarios", x => x.OrdenInventarioId);
                    table.ForeignKey(
                        name: "FK_OrdenInventarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    NumeroFactura = table.Column<string>(maxLength: 10, nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    EstadoCompra = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionProveedores",
                columns: table => new
                {
                    CotizacionProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCotizacion = table.Column<string>(maxLength: 10, nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionProveedores", x => x.CotizacionProveedorId);
                    table.ForeignKey(
                        name: "FK_CotizacionProveedores_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompras",
                columns: table => new
                {
                    OrdenCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    DireccionEntrega = table.Column<string>(maxLength: 150, nullable: true),
                    FormaPago = table.Column<int>(nullable: false),
                    NumeroOrden = table.Column<string>(maxLength: 10, nullable: true),
                    EstadoOrdenCompra = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompras", x => x.OrdenCompraId);
                    table.ForeignKey(
                        name: "FK_OrdenCompras_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenCompras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudCotizaciones",
                columns: table => new
                {
                    SolicitudCotizacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCotizacion = table.Column<string>(maxLength: 10, nullable: true),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudCotizaciones", x => x.SolicitudCotizacionId);
                    table.ForeignKey(
                        name: "FK_SolicitudCotizaciones_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperacionMovimientos",
                columns: table => new
                {
                    OperacionMovimientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoOperacion = table.Column<int>(nullable: false),
                    AlmacenId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoOperacion = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionMovimientos", x => x.OperacionMovimientoId);
                    table.ForeignKey(
                        name: "FK_OperacionMovimientos_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantePagos",
                columns: table => new
                {
                    ComprobantePagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoNumerico = table.Column<string>(maxLength: 8, nullable: false),
                    NumeroComprobante = table.Column<string>(maxLength: 15, nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    DigitoVerificador = table.Column<int>(nullable: false),
                    PuntoEmisionId = table.Column<int>(nullable: false),
                    ComprobanteId = table.Column<int>(nullable: false),
                    TipoIdentificacionId = table.Column<int>(nullable: false),
                    FormaPagoId = table.Column<int>(nullable: false),
                    EstadoCe = table.Column<int>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantePagos", x => x.ComprobantePagoId);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ComprobanteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_EstadoComprobanteElectronicos_EstadoCe",
                        column: x => x.EstadoCe,
                        principalTable: "EstadoComprobanteElectronicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_FormaPagos_FormaPagoId",
                        column: x => x.FormaPagoId,
                        principalTable: "FormaPagos",
                        principalColumn: "FormaPagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_PuntoEmisiones_PuntoEmisionId",
                        column: x => x.PuntoEmisionId,
                        principalTable: "PuntoEmisiones",
                        principalColumn: "PuntoEmisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_TipoIdentificaciones_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificaciones",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobantePagos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NumeradorComprobantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntoEmisionId = table.Column<int>(nullable: false),
                    ComprobanteId = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(maxLength: 6, nullable: true),
                    Secuencial = table.Column<string>(maxLength: 9, nullable: true),
                    Impresora = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeradorComprobantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeradorComprobantes_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ComprobanteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NumeradorComprobantes_PuntoEmisiones_PuntoEmisionId",
                        column: x => x.PuntoEmisionId,
                        principalTable: "PuntoEmisiones",
                        principalColumn: "PuntoEmisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NumeradorOrdenVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntoEmisionId = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(maxLength: 6, nullable: true),
                    Secuencial = table.Column<string>(maxLength: 9, nullable: true),
                    Impresora = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeradorOrdenVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeradorOrdenVentas_PuntoEmisiones_PuntoEmisionId",
                        column: x => x.PuntoEmisionId,
                        principalTable: "PuntoEmisiones",
                        principalColumn: "PuntoEmisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    OperacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntoEmisionId = table.Column<int>(nullable: false),
                    FechaApertura = table.Column<DateTime>(nullable: false),
                    FechaCierre = table.Column<DateTime>(nullable: true),
                    OperacionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.OperacionId);
                    table.ForeignKey(
                        name: "FK_Operaciones_PuntoEmisiones_PuntoEmisionId",
                        column: x => x.PuntoEmisionId,
                        principalTable: "PuntoEmisiones",
                        principalColumn: "PuntoEmisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenVentas",
                columns: table => new
                {
                    OrdenVentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoNumerico = table.Column<string>(maxLength: 9, nullable: true),
                    NumeroComprobante = table.Column<string>(maxLength: 15, nullable: true),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    PuntoEmisionId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenVentas", x => x.OrdenVentaId);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_PuntoEmisiones_PuntoEmisionId",
                        column: x => x.PuntoEmisionId,
                        principalTable: "PuntoEmisiones",
                        principalColumn: "PuntoEmisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoAlmacenes",
                columns: table => new
                {
                    ProductoAlmacenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmacenId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    SaldoMinimo = table.Column<decimal>(nullable: false),
                    SaldoMaximo = table.Column<decimal>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoAlmacenes", x => x.ProductoAlmacenId);
                    table.ForeignKey(
                        name: "FK_ProductoAlmacenes_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoAlmacenes_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoAlmacenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoColor",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoColor", x => new { x.ProductoId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ProductoColor_Colores_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colores",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoColor_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPrecios",
                columns: table => new
                {
                    ProductoPrecioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaPrecioId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    TipoPrecioId = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<decimal>(nullable: false),
                    CantidadMinima = table.Column<decimal>(nullable: false),
                    CantidadMaxima = table.Column<decimal>(nullable: true),
                    Utilidad = table.Column<decimal>(nullable: false),
                    Pvp = table.Column<decimal>(nullable: false),
                    ImporteMinimo = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPrecios", x => x.ProductoPrecioId);
                    table.ForeignKey(
                        name: "FK_ProductoPrecios_ListaPrecios_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "ListaPrecios",
                        principalColumn: "ListaPrecioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoPrecios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => new { x.ProductoId, x.ProveedorId });
                    table.ForeignKey(
                        name: "FK_ProductoProveedor_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoProveedor_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoRequerimientos",
                columns: table => new
                {
                    ProductoRequerimientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequerimientoCompraId = table.Column<int>(nullable: false),
                    AreaNegocioId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoRequerimientos", x => x.ProductoRequerimientoId);
                    table.ForeignKey(
                        name: "FK_ProductoRequerimientos_AreaNegocios_AreaNegocioId",
                        column: x => x.AreaNegocioId,
                        principalTable: "AreaNegocios",
                        principalColumn: "AreaNegocioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRequerimientos_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRequerimientos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRequerimientos_RequerimientoCompras_RequerimientoCompraId",
                        column: x => x.RequerimientoCompraId,
                        principalTable: "RequerimientoCompras",
                        principalColumn: "RequerimientoCompraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTalla",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    TallaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTalla", x => new { x.ProductoId, x.TallaId });
                    table.ForeignKey(
                        name: "FK_ProductoTalla_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTalla_Tallas_TallaId",
                        column: x => x.TallaId,
                        principalTable: "Tallas",
                        principalColumn: "TallaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTasaImpuesto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    TasaImpuestoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTasaImpuesto", x => new { x.ProductoId, x.TasaImpuestoId });
                    table.ForeignKey(
                        name: "FK_ProductoTasaImpuesto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTasaImpuesto_TasaImpuestos_TasaImpuestoId",
                        column: x => x.TasaImpuestoId,
                        principalTable: "TasaImpuestos",
                        principalColumn: "TasaImpuestoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoOrdenInventarios",
                columns: table => new
                {
                    ProductoOrdenInventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenInventarioId = table.Column<int>(nullable: false),
                    ConceptoInventarioId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    TipoOperacion = table.Column<int>(nullable: false),
                    AlmacenId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoOrdenInventarios", x => x.ProductoOrdenInventarioId);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenInventarios_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenInventarios_ConceptoInventarios_ConceptoInventarioId",
                        column: x => x.ConceptoInventarioId,
                        principalTable: "ConceptoInventarios",
                        principalColumn: "ConceptoInventarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenInventarios_OrdenInventarios_OrdenInventarioId",
                        column: x => x.OrdenInventarioId,
                        principalTable: "OrdenInventarios",
                        principalColumn: "OrdenInventarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenInventarios_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenInventarios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroInventarios",
                columns: table => new
                {
                    RegistroInventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionMovimientoId = table.Column<int>(nullable: false),
                    TipoRegistroInventario = table.Column<int>(nullable: false),
                    AlmacenId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaOperacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroInventarios", x => x.RegistroInventarioId);
                    table.ForeignKey(
                        name: "FK_RegistroInventarios_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "AlmacenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroInventarios_OperacionMovimientos_OperacionMovimientoId",
                        column: x => x.OperacionMovimientoId,
                        principalTable: "OperacionMovimientos",
                        principalColumn: "OperacionMovimientoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroInventarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCajas",
                columns: table => new
                {
                    MovimientoCajaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionId = table.Column<int>(nullable: false),
                    ComprobantePagoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    TipoMovimiento = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 500, nullable: true),
                    MontoInicial = table.Column<decimal>(nullable: false),
                    Ingreso = table.Column<decimal>(nullable: false),
                    Egreso = table.Column<decimal>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCajas", x => x.MovimientoCajaId);
                    table.ForeignKey(
                        name: "FK_MovimientoCajas_ComprobantePagos_ComprobantePagoId",
                        column: x => x.ComprobantePagoId,
                        principalTable: "ComprobantePagos",
                        principalColumn: "ComprobantePagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoCajas_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "OperacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoCajas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recuentos",
                columns: table => new
                {
                    RecuentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionId = table.Column<int>(nullable: false),
                    DenominacionId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recuentos", x => x.RecuentoId);
                    table.ForeignKey(
                        name: "FK_Recuentos_Denominaciones_DenominacionId",
                        column: x => x.DenominacionId,
                        principalTable: "Denominaciones",
                        principalColumn: "DenominacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recuentos_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "OperacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenVentas",
                columns: table => new
                {
                    DetalleOrdenVentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenVentaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    ProductoPrecioId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    SubTotalIva = table.Column<decimal>(nullable: false),
                    SubTotalCero = table.Column<decimal>(nullable: false),
                    SubTotalNoObjetoIva = table.Column<decimal>(nullable: false),
                    SubTotalExentoIva = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalDescuento = table.Column<decimal>(nullable: false),
                    ValorIce = table.Column<decimal>(nullable: false),
                    ValorIrbpnr = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenVentas", x => x.DetalleOrdenVentaId);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_OrdenVentas_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVentas",
                        principalColumn: "OrdenVentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVentas_ProductoPrecios_ProductoPrecioId",
                        column: x => x.ProductoPrecioId,
                        principalTable: "ProductoPrecios",
                        principalColumn: "ProductoPrecioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoProductoPrecios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoPrecioId = table.Column<int>(nullable: false),
                    CantidadMinima = table.Column<decimal>(nullable: false),
                    CantidadMaxima = table.Column<decimal>(nullable: false),
                    TipoPrecioId = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<decimal>(nullable: false),
                    Utilidad = table.Column<decimal>(nullable: false),
                    Pvp = table.Column<decimal>(nullable: false),
                    FechaUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoProductoPrecios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoProductoPrecios_ProductoPrecios_ProductoPrecioId",
                        column: x => x.ProductoPrecioId,
                        principalTable: "ProductoPrecios",
                        principalColumn: "ProductoPrecioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCotizaciones",
                columns: table => new
                {
                    ProductoCotizacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudCotizacionId = table.Column<int>(nullable: false),
                    ProductoRequerimientoId = table.Column<int>(nullable: false),
                    FormaPago = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    ValorTasaImpuesto = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false),
                    TotalDescuento = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCotizaciones", x => x.ProductoCotizacionId);
                    table.ForeignKey(
                        name: "FK_ProductoCotizaciones_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizaciones_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizaciones_ProductoRequerimientos_ProductoRequerimientoId",
                        column: x => x.ProductoRequerimientoId,
                        principalTable: "ProductoRequerimientos",
                        principalColumn: "ProductoRequerimientoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizaciones_SolicitudCotizaciones_SolicitudCotizacionId",
                        column: x => x.SolicitudCotizacionId,
                        principalTable: "SolicitudCotizaciones",
                        principalColumn: "SolicitudCotizacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoOperacionMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionMovimientoId = table.Column<int>(nullable: false),
                    ProductoOrdenInventarioId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoOperacionMovimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoOperacionMovimientos_OperacionMovimientos_OperacionMovimientoId",
                        column: x => x.OperacionMovimientoId,
                        principalTable: "OperacionMovimientos",
                        principalColumn: "OperacionMovimientoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOperacionMovimientos_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOperacionMovimientos_ProductoOrdenInventarios_ProductoOrdenInventarioId",
                        column: x => x.ProductoOrdenInventarioId,
                        principalTable: "ProductoOrdenInventarios",
                        principalColumn: "ProductoOrdenInventarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoRegistroInventarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistroInventarioId = table.Column<int>(nullable: false),
                    ProductoOrdenInventarioId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoRegistroInventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoRegistroInventarios_ProductoOrdenInventarios_ProductoOrdenInventarioId",
                        column: x => x.ProductoOrdenInventarioId,
                        principalTable: "ProductoOrdenInventarios",
                        principalColumn: "ProductoOrdenInventarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRegistroInventarios_RegistroInventarios_RegistroInventarioId",
                        column: x => x.RegistroInventarioId,
                        principalTable: "RegistroInventarios",
                        principalColumn: "RegistroInventarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleComprobantePagos",
                columns: table => new
                {
                    DetalleComprobantePagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprobantePagoId = table.Column<int>(nullable: false),
                    DetalleOrdenVentaId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    ProductoPrecioId = table.Column<int>(nullable: false),
                    SubTotalIva = table.Column<decimal>(nullable: false),
                    SubTotalCero = table.Column<decimal>(nullable: false),
                    SubTotalNoObjetoIva = table.Column<decimal>(nullable: false),
                    SubTotalExentoIva = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalDescuento = table.Column<decimal>(nullable: false),
                    ValorIce = table.Column<decimal>(nullable: false),
                    ValorIrbpnr = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false),
                    Propina = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleComprobantePagos", x => x.DetalleComprobantePagoId);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantePagos_ComprobantePagos_ComprobantePagoId",
                        column: x => x.ComprobantePagoId,
                        principalTable: "ComprobantePagos",
                        principalColumn: "ComprobantePagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantePagos_DetalleOrdenVentas_DetalleOrdenVentaId",
                        column: x => x.DetalleOrdenVentaId,
                        principalTable: "DetalleOrdenVentas",
                        principalColumn: "DetalleOrdenVentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantePagos_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantePagos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantePagos_ProductoPrecios_ProductoPrecioId",
                        column: x => x.ProductoPrecioId,
                        principalTable: "ProductoPrecios",
                        principalColumn: "ProductoPrecioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCotizacionProveedores",
                columns: table => new
                {
                    ProductoCotizacionProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotizacionProveedorId = table.Column<int>(nullable: false),
                    ProductoCotizacionId = table.Column<int>(nullable: false),
                    FormaPago = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    PrecioCompra = table.Column<decimal>(nullable: false),
                    TasaImpuesto = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCotizacionProveedores", x => x.ProductoCotizacionProveedorId);
                    table.ForeignKey(
                        name: "FK_ProductoCotizacionProveedores_CotizacionProveedores_CotizacionProveedorId",
                        column: x => x.CotizacionProveedorId,
                        principalTable: "CotizacionProveedores",
                        principalColumn: "CotizacionProveedorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizacionProveedores_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizacionProveedores_ProductoCotizaciones_ProductoCotizacionId",
                        column: x => x.ProductoCotizacionId,
                        principalTable: "ProductoCotizaciones",
                        principalColumn: "ProductoCotizacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCotizacionProveedores_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoInventarios",
                columns: table => new
                {
                    MovimientoInventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoAlmacenId = table.Column<int>(nullable: false),
                    ProductoOperacionMovimientoId = table.Column<int>(nullable: false),
                    ProductoRegistroInventarioId = table.Column<int>(nullable: false),
                    FechaOperacionInventario = table.Column<DateTime>(nullable: false),
                    CantidadSaldoInicial = table.Column<decimal>(nullable: false),
                    CostoUnitarioSaldoInicial = table.Column<decimal>(nullable: false),
                    CostoTotalSaldoInical = table.Column<decimal>(nullable: false),
                    CantidadEntrada = table.Column<decimal>(nullable: false),
                    CostoUnitarioEntrada = table.Column<decimal>(nullable: false),
                    CostoTotalEntrada = table.Column<decimal>(nullable: false),
                    CantidadSalida = table.Column<decimal>(nullable: false),
                    CostoUnitarioSalida = table.Column<decimal>(nullable: false),
                    CostoTotalSalida = table.Column<decimal>(nullable: false),
                    CantidadSaldoFinal = table.Column<decimal>(nullable: false),
                    CostoUnitarioSaldoFinal = table.Column<decimal>(nullable: false),
                    CostoTotalSaldoFinal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoInventarios", x => x.MovimientoInventarioId);
                    table.ForeignKey(
                        name: "FK_MovimientoInventarios_ProductoAlmacenes_ProductoAlmacenId",
                        column: x => x.ProductoAlmacenId,
                        principalTable: "ProductoAlmacenes",
                        principalColumn: "ProductoAlmacenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoInventarios_ProductoOperacionMovimientos_ProductoOperacionMovimientoId",
                        column: x => x.ProductoOperacionMovimientoId,
                        principalTable: "ProductoOperacionMovimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoInventarios_ProductoRegistroInventarios_ProductoRegistroInventarioId",
                        column: x => x.ProductoRegistroInventarioId,
                        principalTable: "ProductoRegistroInventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImpuestoVentas",
                columns: table => new
                {
                    ImpuestoVentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalleComprobantePagoId = table.Column<int>(nullable: false),
                    TasaImpuestoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpuestoVentas", x => x.ImpuestoVentaId);
                    table.ForeignKey(
                        name: "FK_ImpuestoVentas_DetalleComprobantePagos_DetalleComprobantePagoId",
                        column: x => x.DetalleComprobantePagoId,
                        principalTable: "DetalleComprobantePagos",
                        principalColumn: "DetalleComprobantePagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImpuestoVentas_TasaImpuestos_TasaImpuestoId",
                        column: x => x.TasaImpuestoId,
                        principalTable: "TasaImpuestos",
                        principalColumn: "TasaImpuestoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoOrdenCompras",
                columns: table => new
                {
                    ProductoOrdenCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenCompraId = table.Column<int>(nullable: false),
                    ProductoCotizacionProveedorId = table.Column<int>(nullable: false),
                    Impuesto = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    SubTotalIva = table.Column<decimal>(nullable: false),
                    SubTotalCero = table.Column<decimal>(nullable: false),
                    SubTotalNoObjetoIva = table.Column<decimal>(nullable: false),
                    SubTotalExcentoIva = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalDescuento = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoOrdenCompras", x => x.ProductoOrdenCompraId);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenCompras_Medidas_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medidas",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenCompras_OrdenCompras_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "OrdenCompras",
                        principalColumn: "OrdenCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenCompras_ProductoCotizacionProveedores_ProductoCotizacionProveedorId",
                        column: x => x.ProductoCotizacionProveedorId,
                        principalTable: "ProductoCotizacionProveedores",
                        principalColumn: "ProductoCotizacionProveedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoOrdenCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCompras",
                columns: table => new
                {
                    ProductoCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(nullable: false),
                    ProductoOrdenCompraId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    PresentacionId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    PrecioCompra = table.Column<decimal>(nullable: false),
                    SubTotalIva = table.Column<decimal>(nullable: false),
                    SubTotalCero = table.Column<decimal>(nullable: false),
                    SubTotalNoObjetoIva = table.Column<decimal>(nullable: false),
                    SubTotalExentoIva = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalDescuento = table.Column<decimal>(nullable: false),
                    ValorIce = table.Column<decimal>(nullable: false),
                    ValorIrbpnr = table.Column<decimal>(nullable: false),
                    ValorIva = table.Column<decimal>(nullable: false),
                    Propina = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCompras", x => x.ProductoCompraId);
                    table.ForeignKey(
                        name: "FK_ProductoCompras_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCompras_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "PresentacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCompras_ProductoOrdenCompras_ProductoOrdenCompraId",
                        column: x => x.ProductoOrdenCompraId,
                        principalTable: "ProductoOrdenCompras",
                        principalColumn: "ProductoOrdenCompraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Almacenes_EstablecimientoId",
                table: "Almacenes",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoIdentificacionId",
                table: "Clientes",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_ClienteId",
                table: "ComprobantePagos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_ComprobanteId",
                table: "ComprobantePagos",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_EstadoCe",
                table: "ComprobantePagos",
                column: "EstadoCe");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_FormaPagoId",
                table: "ComprobantePagos",
                column: "FormaPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_PuntoEmisionId",
                table: "ComprobantePagos",
                column: "PuntoEmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_TipoIdentificacionId",
                table: "ComprobantePagos",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantePagos_UsuarioId",
                table: "ComprobantePagos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteTipoIdentificacion_TipoIdentificacionId",
                table: "ComprobanteTipoIdentificacion",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProveedores_ProveedorId",
                table: "CotizacionProveedores",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantePagos_ComprobantePagoId",
                table: "DetalleComprobantePagos",
                column: "ComprobantePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantePagos_DetalleOrdenVentaId",
                table: "DetalleComprobantePagos",
                column: "DetalleOrdenVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantePagos_PresentacionId",
                table: "DetalleComprobantePagos",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantePagos_ProductoId",
                table: "DetalleComprobantePagos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantePagos_ProductoPrecioId",
                table: "DetalleComprobantePagos",
                column: "ProductoPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVentas",
                column: "OrdenVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_PresentacionId",
                table: "DetalleOrdenVentas",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_ProductoId",
                table: "DetalleOrdenVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVentas_ProductoPrecioId",
                table: "DetalleOrdenVentas",
                column: "ProductoPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_Establecimientos_EmpresaId",
                table: "Establecimientos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoProductoPrecios_ProductoPrecioId",
                table: "HistoricoProductoPrecios",
                column: "ProductoPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpuestoVentas_DetalleComprobantePagoId",
                table: "ImpuestoVentas",
                column: "DetalleComprobantePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpuestoVentas_TasaImpuestoId",
                table: "ImpuestoVentas",
                column: "TasaImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCajas_ComprobantePagoId",
                table: "MovimientoCajas",
                column: "ComprobantePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCajas_OperacionId",
                table: "MovimientoCajas",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCajas_UsuarioId",
                table: "MovimientoCajas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventarios_ProductoAlmacenId",
                table: "MovimientoInventarios",
                column: "ProductoAlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventarios_ProductoOperacionMovimientoId",
                table: "MovimientoInventarios",
                column: "ProductoOperacionMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventarios_ProductoRegistroInventarioId",
                table: "MovimientoInventarios",
                column: "ProductoRegistroInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NumeradorComprobantes_ComprobanteId",
                table: "NumeradorComprobantes",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_NumeradorComprobantes_PuntoEmisionId",
                table: "NumeradorComprobantes",
                column: "PuntoEmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_NumeradorOrdenVentas_PuntoEmisionId",
                table: "NumeradorOrdenVentas",
                column: "PuntoEmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_PuntoEmisionId",
                table: "Operaciones",
                column: "PuntoEmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionMovimientos_AlmacenId",
                table: "OperacionMovimientos",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_ProveedorId",
                table: "OrdenCompras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_UsuarioId",
                table: "OrdenCompras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenInventarios_UsuarioId",
                table: "OrdenInventarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_ClienteId",
                table: "OrdenVentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_PuntoEmisionId",
                table: "OrdenVentas",
                column: "PuntoEmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_UsuarioId",
                table: "OrdenVentas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_MedidaId",
                table: "Presentaciones",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAlmacenes_AlmacenId",
                table: "ProductoAlmacenes",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAlmacenes_PresentacionId",
                table: "ProductoAlmacenes",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAlmacenes_ProductoId",
                table: "ProductoAlmacenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoColor_ColorId",
                table: "ProductoColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCompras_CompraId",
                table: "ProductoCompras",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCompras_PresentacionId",
                table: "ProductoCompras",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCompras_ProductoId",
                table: "ProductoCompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCompras_ProductoOrdenCompraId",
                table: "ProductoCompras",
                column: "ProductoOrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizaciones_MedidaId",
                table: "ProductoCotizaciones",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizaciones_ProductoId",
                table: "ProductoCotizaciones",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizaciones_ProductoRequerimientoId",
                table: "ProductoCotizaciones",
                column: "ProductoRequerimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizaciones_SolicitudCotizacionId",
                table: "ProductoCotizaciones",
                column: "SolicitudCotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizacionProveedores_CotizacionProveedorId",
                table: "ProductoCotizacionProveedores",
                column: "CotizacionProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizacionProveedores_MedidaId",
                table: "ProductoCotizacionProveedores",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizacionProveedores_ProductoCotizacionId",
                table: "ProductoCotizacionProveedores",
                column: "ProductoCotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCotizacionProveedores_ProductoId",
                table: "ProductoCotizacionProveedores",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOperacionMovimientos_OperacionMovimientoId",
                table: "ProductoOperacionMovimientos",
                column: "OperacionMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOperacionMovimientos_PresentacionId",
                table: "ProductoOperacionMovimientos",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOperacionMovimientos_ProductoOrdenInventarioId",
                table: "ProductoOperacionMovimientos",
                column: "ProductoOrdenInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenCompras_MedidaId",
                table: "ProductoOrdenCompras",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenCompras_OrdenCompraId",
                table: "ProductoOrdenCompras",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenCompras_ProductoCotizacionProveedorId",
                table: "ProductoOrdenCompras",
                column: "ProductoCotizacionProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenCompras_ProductoId",
                table: "ProductoOrdenCompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenInventarios_AlmacenId",
                table: "ProductoOrdenInventarios",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenInventarios_ConceptoInventarioId",
                table: "ProductoOrdenInventarios",
                column: "ConceptoInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenInventarios_OrdenInventarioId",
                table: "ProductoOrdenInventarios",
                column: "OrdenInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenInventarios_PresentacionId",
                table: "ProductoOrdenInventarios",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOrdenInventarios_ProductoId",
                table: "ProductoOrdenInventarios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPrecios_ListaPrecioId",
                table: "ProductoPrecios",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPrecios_ProductoId",
                table: "ProductoPrecios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedor_ProveedorId",
                table: "ProductoProveedor",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistroInventarios_ProductoOrdenInventarioId",
                table: "ProductoRegistroInventarios",
                column: "ProductoOrdenInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistroInventarios_RegistroInventarioId",
                table: "ProductoRegistroInventarios",
                column: "RegistroInventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRequerimientos_AreaNegocioId",
                table: "ProductoRequerimientos",
                column: "AreaNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRequerimientos_MedidaId",
                table: "ProductoRequerimientos",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRequerimientos_ProductoId",
                table: "ProductoRequerimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRequerimientos_RequerimientoCompraId",
                table: "ProductoRequerimientos",
                column: "RequerimientoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_LaboratorioId",
                table: "Productos",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MedidaId",
                table: "Productos",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MonedaId",
                table: "Productos",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PresentacionId",
                table: "Productos",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SubCategoriaId",
                table: "Productos",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TallaId",
                table: "Productos",
                column: "TallaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTalla_TallaId",
                table: "ProductoTalla",
                column: "TallaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTasaImpuesto_TasaImpuestoId",
                table: "ProductoTasaImpuesto",
                column: "TasaImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TipoIdentificacionId",
                table: "Proveedores",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_UbigeoId",
                table: "Proveedores",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoEmisiones_EstablecimientoId",
                table: "PuntoEmisiones",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuentos_DenominacionId",
                table: "Recuentos",
                column: "DenominacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuentos_OperacionId",
                table: "Recuentos",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroInventarios_AlmacenId",
                table: "RegistroInventarios",
                column: "AlmacenId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroInventarios_OperacionMovimientoId",
                table: "RegistroInventarios",
                column: "OperacionMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroInventarios_UsuarioId",
                table: "RegistroInventarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RolFuncion_FuncionId",
                table: "RolFuncion",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudCotizaciones_ProveedorId",
                table: "SolicitudCotizaciones",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TasaImpuestos_ImpuestoId",
                table: "TasaImpuestos",
                column: "ImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobanteTipoIdentificacion");

            migrationBuilder.DropTable(
                name: "HistoricoProductoPrecios");

            migrationBuilder.DropTable(
                name: "ImpuestoVentas");

            migrationBuilder.DropTable(
                name: "MovimientoCajas");

            migrationBuilder.DropTable(
                name: "MovimientoInventarios");

            migrationBuilder.DropTable(
                name: "NumeradorComprobantes");

            migrationBuilder.DropTable(
                name: "NumeradorOrdenVentas");

            migrationBuilder.DropTable(
                name: "ProductoColor");

            migrationBuilder.DropTable(
                name: "ProductoCompras");

            migrationBuilder.DropTable(
                name: "ProductoProveedor");

            migrationBuilder.DropTable(
                name: "ProductoTalla");

            migrationBuilder.DropTable(
                name: "ProductoTasaImpuesto");

            migrationBuilder.DropTable(
                name: "Recuentos");

            migrationBuilder.DropTable(
                name: "RolFuncion");

            migrationBuilder.DropTable(
                name: "DetalleComprobantePagos");

            migrationBuilder.DropTable(
                name: "ProductoAlmacenes");

            migrationBuilder.DropTable(
                name: "ProductoOperacionMovimientos");

            migrationBuilder.DropTable(
                name: "ProductoRegistroInventarios");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "ProductoOrdenCompras");

            migrationBuilder.DropTable(
                name: "TasaImpuestos");

            migrationBuilder.DropTable(
                name: "Denominaciones");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "ComprobantePagos");

            migrationBuilder.DropTable(
                name: "DetalleOrdenVentas");

            migrationBuilder.DropTable(
                name: "ProductoOrdenInventarios");

            migrationBuilder.DropTable(
                name: "RegistroInventarios");

            migrationBuilder.DropTable(
                name: "OrdenCompras");

            migrationBuilder.DropTable(
                name: "ProductoCotizacionProveedores");

            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "EstadoComprobanteElectronicos");

            migrationBuilder.DropTable(
                name: "FormaPagos");

            migrationBuilder.DropTable(
                name: "OrdenVentas");

            migrationBuilder.DropTable(
                name: "ProductoPrecios");

            migrationBuilder.DropTable(
                name: "ConceptoInventarios");

            migrationBuilder.DropTable(
                name: "OrdenInventarios");

            migrationBuilder.DropTable(
                name: "OperacionMovimientos");

            migrationBuilder.DropTable(
                name: "CotizacionProveedores");

            migrationBuilder.DropTable(
                name: "ProductoCotizaciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PuntoEmisiones");

            migrationBuilder.DropTable(
                name: "ListaPrecios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Almacenes");

            migrationBuilder.DropTable(
                name: "ProductoRequerimientos");

            migrationBuilder.DropTable(
                name: "SolicitudCotizaciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Establecimientos");

            migrationBuilder.DropTable(
                name: "AreaNegocios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RequerimientoCompras");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "Presentaciones");

            migrationBuilder.DropTable(
                name: "SubCategorias");

            migrationBuilder.DropTable(
                name: "Tallas");

            migrationBuilder.DropTable(
                name: "TipoIdentificaciones");

            migrationBuilder.DropTable(
                name: "Ubigeos");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
