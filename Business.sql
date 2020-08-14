IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AreaNegocios] (
    [AreaNegocioId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(200) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_AreaNegocios] PRIMARY KEY ([AreaNegocioId])
);

GO

CREATE TABLE [Categorias] (
    [CategoriaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([CategoriaId])
);

GO

CREATE TABLE [Colores] (
    [ColorId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    CONSTRAINT [PK_Colores] PRIMARY KEY ([ColorId])
);

GO

CREATE TABLE [Comprobantes] (
    [ComprobanteId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    [Codigo] nvarchar(2) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Comprobantes] PRIMARY KEY ([ComprobanteId])
);

GO

CREATE TABLE [ConceptoInventarios] (
    [ConceptoInventarioId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    [TipoOperacion] int NOT NULL,
    CONSTRAINT [PK_ConceptoInventarios] PRIMARY KEY ([ConceptoInventarioId])
);

GO

CREATE TABLE [Denominaciones] (
    [DenominacionId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Denominaciones] PRIMARY KEY ([DenominacionId])
);

GO

CREATE TABLE [Empresas] (
    [EmpresaId] int NOT NULL IDENTITY,
    [Ruc] nvarchar(13) NULL,
    [RazonSocial] nvarchar(300) NULL,
    [Direccion] nvarchar(300) NULL,
    [TelefonoFijo] nvarchar(10) NULL,
    [TelefonoCelular] nvarchar(10) NULL,
    [Representante] nvarchar(100) NULL,
    [Email] nvarchar(100) NULL,
    [ClaveEmail] nvarchar(30) NULL,
    [ObligadoContabilidad] int NOT NULL,
    [Emision] int NOT NULL,
    [Ambiente] int NOT NULL,
    [LogoEmisor] varbinary(max) NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY ([EmpresaId])
);

GO

CREATE TABLE [EstadoComprobanteElectronicos] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(100) NULL,
    [Siglas] nvarchar(50) NULL,
    CONSTRAINT [PK_EstadoComprobanteElectronicos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [FormaPagos] (
    [FormaPagoId] int NOT NULL IDENTITY,
    [Codigo] nvarchar(2) NULL,
    [Nombre] nvarchar(200) NULL,
    CONSTRAINT [PK_FormaPagos] PRIMARY KEY ([FormaPagoId])
);

GO

CREATE TABLE [Funciones] (
    [FuncionId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    CONSTRAINT [PK_Funciones] PRIMARY KEY ([FuncionId])
);

GO

CREATE TABLE [Impuestos] (
    [ImpuestoId] int NOT NULL IDENTITY,
    [Codigo] nvarchar(2) NULL,
    [Nombre] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Impuestos] PRIMARY KEY ([ImpuestoId])
);

GO

CREATE TABLE [Laboratorios] (
    [LaboratorioId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    [Representante] nvarchar(100) NULL,
    [Direccion] nvarchar(100) NULL,
    [Telefono] nvarchar(10) NULL,
    [Email] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Laboratorios] PRIMARY KEY ([LaboratorioId])
);

GO

CREATE TABLE [ListaPrecios] (
    [ListaPrecioId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(200) NULL,
    [FechaInicio] datetime2 NOT NULL,
    [FechaFin] datetime2 NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_ListaPrecios] PRIMARY KEY ([ListaPrecioId])
);

GO

CREATE TABLE [Marcas] (
    [MarcaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([MarcaId])
);

GO

CREATE TABLE [Medidas] (
    [MedidaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(60) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Medidas] PRIMARY KEY ([MedidaId])
);

GO

CREATE TABLE [Monedas] (
    [MonedaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Monedas] PRIMARY KEY ([MonedaId])
);

GO

CREATE TABLE [RequerimientoCompras] (
    [RequerimientoCompraId] int NOT NULL IDENTITY,
    [NumeroRequerimiento] nvarchar(10) NULL,
    [FechaEmision] datetime2 NOT NULL,
    [FechaEntrega] datetime2 NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_RequerimientoCompras] PRIMARY KEY ([RequerimientoCompraId])
);

GO

CREATE TABLE [Roles] (
    [RolId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RolId])
);

GO

CREATE TABLE [Tallas] (
    [TallaId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    CONSTRAINT [PK_Tallas] PRIMARY KEY ([TallaId])
);

GO

CREATE TABLE [TipoIdentificaciones] (
    [TipoIdentificacionId] int NOT NULL IDENTITY,
    [Codigo] nvarchar(2) NULL,
    [Nombre] nvarchar(200) NULL,
    CONSTRAINT [PK_TipoIdentificaciones] PRIMARY KEY ([TipoIdentificacionId])
);

GO

CREATE TABLE [Ubigeos] (
    [UbigeoId] int NOT NULL IDENTITY,
    [CodigoProvincia] nvarchar(2) NULL,
    [Provincia] nvarchar(100) NULL,
    [CodigoCanton] nvarchar(4) NULL,
    [Canton] nvarchar(100) NULL,
    [CodigoParroquia] nvarchar(6) NULL,
    [Parroquia] nvarchar(100) NULL,
    CONSTRAINT [PK_Ubigeos] PRIMARY KEY ([UbigeoId])
);

GO

CREATE TABLE [SubCategorias] (
    [SubCategoriaId] int NOT NULL IDENTITY,
    [CategoriaId] int NOT NULL,
    [Nombre] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_SubCategorias] PRIMARY KEY ([SubCategoriaId]),
    CONSTRAINT [FK_SubCategorias_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([CategoriaId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Establecimientos] (
    [EstablecimientoId] int NOT NULL IDENTITY,
    [EmpresaId] int NOT NULL,
    [Codigo] nvarchar(3) NULL,
    [Nombre] nvarchar(120) NULL,
    [Direccion] nvarchar(200) NULL,
    [TelefonoFijo] nvarchar(10) NULL,
    [TelefonoCelular] nvarchar(10) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Establecimientos] PRIMARY KEY ([EstablecimientoId]),
    CONSTRAINT [FK_Establecimientos_Empresas_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresas] ([EmpresaId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TasaImpuestos] (
    [TasaImpuestoId] int NOT NULL IDENTITY,
    [ImpuestoId] int NOT NULL,
    [Codigo] nvarchar(4) NOT NULL,
    [Nombre] nvarchar(100) NULL,
    [Concepto] nvarchar(500) NULL,
    [Tasa] decimal(18,2) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_TasaImpuestos] PRIMARY KEY ([TasaImpuestoId]),
    CONSTRAINT [FK_TasaImpuestos_Impuestos_ImpuestoId] FOREIGN KEY ([ImpuestoId]) REFERENCES [Impuestos] ([ImpuestoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Presentaciones] (
    [PresentacionId] int NOT NULL IDENTITY,
    [MedidaId] int NOT NULL,
    [Nombre] nvarchar(80) NULL,
    [Abreviacion] nvarchar(50) NULL,
    [Equivalencia] decimal(18,2) NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Presentaciones] PRIMARY KEY ([PresentacionId]),
    CONSTRAINT [FK_Presentaciones_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [RolFuncion] (
    [RolId] int NOT NULL,
    [FuncionId] int NOT NULL,
    CONSTRAINT [PK_RolFuncion] PRIMARY KEY ([RolId], [FuncionId]),
    CONSTRAINT [FK_RolFuncion_Funciones_FuncionId] FOREIGN KEY ([FuncionId]) REFERENCES [Funciones] ([FuncionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolFuncion_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([RolId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Usuarios] (
    [UsuarioId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NULL,
    [RolId] int NOT NULL,
    [User] nvarchar(15) NULL,
    [Password] nvarchar(200) NULL,
    [Foto] varbinary(max) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([UsuarioId]),
    CONSTRAINT [FK_Usuarios_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([RolId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Clientes] (
    [ClienteId] int NOT NULL IDENTITY,
    [TipoIdentificacionId] int NOT NULL,
    [Numero] nvarchar(20) NULL,
    [RazonSocial] nvarchar(300) NULL,
    [Direccion] nvarchar(300) NULL,
    [Telefono] nvarchar(10) NULL,
    [Email] nvarchar(100) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([ClienteId]),
    CONSTRAINT [FK_Clientes_TipoIdentificaciones_TipoIdentificacionId] FOREIGN KEY ([TipoIdentificacionId]) REFERENCES [TipoIdentificaciones] ([TipoIdentificacionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ComprobanteTipoIdentificacion] (
    [ComprobanteId] int NOT NULL,
    [TipoIdentificacionId] int NOT NULL,
    CONSTRAINT [PK_ComprobanteTipoIdentificacion] PRIMARY KEY ([ComprobanteId], [TipoIdentificacionId]),
    CONSTRAINT [FK_ComprobanteTipoIdentificacion_Comprobantes_ComprobanteId] FOREIGN KEY ([ComprobanteId]) REFERENCES [Comprobantes] ([ComprobanteId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ComprobanteTipoIdentificacion_TipoIdentificaciones_TipoIdentificacionId] FOREIGN KEY ([TipoIdentificacionId]) REFERENCES [TipoIdentificaciones] ([TipoIdentificacionId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Proveedores] (
    [ProveedorId] int NOT NULL IDENTITY,
    [TipoIdentificacionId] int NOT NULL,
    [Numero] nvarchar(18) NULL,
    [RazonSocial] nvarchar(100) NULL,
    [Representante] nvarchar(100) NULL,
    [UbigeoId] int NOT NULL,
    [Direccion] nvarchar(100) NULL,
    [Telefono] nvarchar(10) NULL,
    [EmailProveedor] nvarchar(80) NULL,
    [EmailVendedor] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Proveedores] PRIMARY KEY ([ProveedorId]),
    CONSTRAINT [FK_Proveedores_TipoIdentificaciones_TipoIdentificacionId] FOREIGN KEY ([TipoIdentificacionId]) REFERENCES [TipoIdentificaciones] ([TipoIdentificacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Proveedores_Ubigeos_UbigeoId] FOREIGN KEY ([UbigeoId]) REFERENCES [Ubigeos] ([UbigeoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Almacenes] (
    [AlmacenId] int NOT NULL IDENTITY,
    [EstablecimientoId] int NOT NULL,
    [Nombre] nvarchar(80) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Almacenes] PRIMARY KEY ([AlmacenId]),
    CONSTRAINT [FK_Almacenes_Establecimientos_EstablecimientoId] FOREIGN KEY ([EstablecimientoId]) REFERENCES [Establecimientos] ([EstablecimientoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PuntoEmisiones] (
    [PuntoEmisionId] int NOT NULL IDENTITY,
    [EstablecimientoId] int NOT NULL,
    [Codigo] nvarchar(3) NULL,
    [Nombre] nvarchar(120) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_PuntoEmisiones] PRIMARY KEY ([PuntoEmisionId]),
    CONSTRAINT [FK_PuntoEmisiones_Establecimientos_EstablecimientoId] FOREIGN KEY ([EstablecimientoId]) REFERENCES [Establecimientos] ([EstablecimientoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Productos] (
    [ProductoId] int NOT NULL IDENTITY,
    [TipoProducto] int NOT NULL,
    [Codigo] nvarchar(13) NULL,
    [CodigoBarra] nvarchar(15) NULL,
    [Nombre] nvarchar(200) NULL,
    [CategoriaId] int NOT NULL,
    [SubCategoriaId] int NOT NULL,
    [MarcaId] int NULL,
    [MonedaId] int NOT NULL,
    [MedidaId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [LaboratorioId] int NULL,
    [FechaVencimiento] datetime2 NULL,
    [PrecioCompra] decimal(18,2) NOT NULL,
    [Lote] nvarchar(10) NULL,
    [IncluyeImpuesto] int NOT NULL,
    [Estado] int NOT NULL,
    [CalculoImportePorRangos] bit NOT NULL,
    [PrecioBase] decimal(18,2) NOT NULL,
    [TallaId] int NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([ProductoId]),
    CONSTRAINT [FK_Productos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([CategoriaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Laboratorios_LaboratorioId] FOREIGN KEY ([LaboratorioId]) REFERENCES [Laboratorios] ([LaboratorioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Marcas_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas] ([MarcaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Monedas_MonedaId] FOREIGN KEY ([MonedaId]) REFERENCES [Monedas] ([MonedaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_SubCategorias_SubCategoriaId] FOREIGN KEY ([SubCategoriaId]) REFERENCES [SubCategorias] ([SubCategoriaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Productos_Tallas_TallaId] FOREIGN KEY ([TallaId]) REFERENCES [Tallas] ([TallaId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OrdenInventarios] (
    [OrdenInventarioId] int NOT NULL IDENTITY,
    [NumeroOrden] nvarchar(10) NULL,
    [Fecha] datetime2 NOT NULL,
    [UsuarioId] int NOT NULL,
    [EstadoOrden] int NOT NULL,
    CONSTRAINT [PK_OrdenInventarios] PRIMARY KEY ([OrdenInventarioId]),
    CONSTRAINT [FK_OrdenInventarios_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Compras] (
    [CompraId] int NOT NULL IDENTITY,
    [ProveedorId] int NOT NULL,
    [FechaCompra] datetime2 NOT NULL,
    [NumeroFactura] nvarchar(10) NULL,
    [UsuarioId] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    [EstadoCompra] int NOT NULL,
    CONSTRAINT [PK_Compras] PRIMARY KEY ([CompraId]),
    CONSTRAINT [FK_Compras_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([ProveedorId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Compras_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CotizacionProveedores] (
    [CotizacionProveedorId] int NOT NULL IDENTITY,
    [NumeroCotizacion] nvarchar(10) NULL,
    [FechaInicio] datetime2 NOT NULL,
    [FechaFin] datetime2 NOT NULL,
    [ProveedorId] int NOT NULL,
    [Estado] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_CotizacionProveedores] PRIMARY KEY ([CotizacionProveedorId]),
    CONSTRAINT [FK_CotizacionProveedores_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([ProveedorId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OrdenCompras] (
    [OrdenCompraId] int NOT NULL IDENTITY,
    [ProveedorId] int NOT NULL,
    [FechaEmision] datetime2 NOT NULL,
    [FechaEntrega] datetime2 NOT NULL,
    [DireccionEntrega] nvarchar(150) NULL,
    [FormaPago] int NOT NULL,
    [NumeroOrden] nvarchar(10) NULL,
    [EstadoOrdenCompra] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_OrdenCompras] PRIMARY KEY ([OrdenCompraId]),
    CONSTRAINT [FK_OrdenCompras_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([ProveedorId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrdenCompras_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [SolicitudCotizaciones] (
    [SolicitudCotizacionId] int NOT NULL IDENTITY,
    [NumeroCotizacion] nvarchar(10) NULL,
    [FechaEmision] datetime2 NOT NULL,
    [FechaEntrega] datetime2 NOT NULL,
    [ProveedorId] int NOT NULL,
    [Estado] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_SolicitudCotizaciones] PRIMARY KEY ([SolicitudCotizacionId]),
    CONSTRAINT [FK_SolicitudCotizaciones_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([ProveedorId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OperacionMovimientos] (
    [OperacionMovimientoId] int NOT NULL IDENTITY,
    [EstadoOperacion] int NOT NULL,
    [AlmacenId] int NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [TipoOperacion] int NOT NULL,
    [Referencia] nvarchar(20) NULL,
    CONSTRAINT [PK_OperacionMovimientos] PRIMARY KEY ([OperacionMovimientoId]),
    CONSTRAINT [FK_OperacionMovimientos_Almacenes_AlmacenId] FOREIGN KEY ([AlmacenId]) REFERENCES [Almacenes] ([AlmacenId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ComprobantePagos] (
    [ComprobantePagoId] int NOT NULL IDENTITY,
    [CodigoNumerico] nvarchar(8) NOT NULL,
    [NumeroComprobante] nvarchar(15) NOT NULL,
    [ClienteId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [FechaEmision] datetime2 NOT NULL,
    [DigitoVerificador] int NOT NULL,
    [PuntoEmisionId] int NOT NULL,
    [ComprobanteId] int NOT NULL,
    [TipoIdentificacionId] int NOT NULL,
    [FormaPagoId] int NOT NULL,
    [EstadoCe] int NULL,
    [Estado] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ComprobantePagos] PRIMARY KEY ([ComprobantePagoId]),
    CONSTRAINT [FK_ComprobantePagos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([ClienteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_Comprobantes_ComprobanteId] FOREIGN KEY ([ComprobanteId]) REFERENCES [Comprobantes] ([ComprobanteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_EstadoComprobanteElectronicos_EstadoCe] FOREIGN KEY ([EstadoCe]) REFERENCES [EstadoComprobanteElectronicos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_FormaPagos_FormaPagoId] FOREIGN KEY ([FormaPagoId]) REFERENCES [FormaPagos] ([FormaPagoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_PuntoEmisiones_PuntoEmisionId] FOREIGN KEY ([PuntoEmisionId]) REFERENCES [PuntoEmisiones] ([PuntoEmisionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_TipoIdentificaciones_TipoIdentificacionId] FOREIGN KEY ([TipoIdentificacionId]) REFERENCES [TipoIdentificaciones] ([TipoIdentificacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ComprobantePagos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [NumeradorComprobantes] (
    [Id] int NOT NULL IDENTITY,
    [PuntoEmisionId] int NOT NULL,
    [ComprobanteId] int NOT NULL,
    [Serie] nvarchar(6) NULL,
    [Secuencial] nvarchar(9) NULL,
    [Impresora] nvarchar(50) NULL,
    CONSTRAINT [PK_NumeradorComprobantes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NumeradorComprobantes_Comprobantes_ComprobanteId] FOREIGN KEY ([ComprobanteId]) REFERENCES [Comprobantes] ([ComprobanteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_NumeradorComprobantes_PuntoEmisiones_PuntoEmisionId] FOREIGN KEY ([PuntoEmisionId]) REFERENCES [PuntoEmisiones] ([PuntoEmisionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [NumeradorOrdenVentas] (
    [Id] int NOT NULL IDENTITY,
    [PuntoEmisionId] int NOT NULL,
    [Serie] nvarchar(6) NULL,
    [Secuencial] nvarchar(9) NULL,
    [Impresora] nvarchar(50) NULL,
    CONSTRAINT [PK_NumeradorOrdenVentas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NumeradorOrdenVentas_PuntoEmisiones_PuntoEmisionId] FOREIGN KEY ([PuntoEmisionId]) REFERENCES [PuntoEmisiones] ([PuntoEmisionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Operaciones] (
    [OperacionId] int NOT NULL IDENTITY,
    [PuntoEmisionId] int NOT NULL,
    [FechaApertura] datetime2 NOT NULL,
    [FechaCierre] datetime2 NULL,
    [OperacionStatus] int NOT NULL,
    CONSTRAINT [PK_Operaciones] PRIMARY KEY ([OperacionId]),
    CONSTRAINT [FK_Operaciones_PuntoEmisiones_PuntoEmisionId] FOREIGN KEY ([PuntoEmisionId]) REFERENCES [PuntoEmisiones] ([PuntoEmisionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OrdenVentas] (
    [OrdenVentaId] int NOT NULL IDENTITY,
    [CodigoNumerico] nvarchar(9) NULL,
    [NumeroComprobante] nvarchar(15) NULL,
    [FechaEmision] datetime2 NOT NULL,
    [FechaEntrega] datetime2 NULL,
    [ClienteId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [PuntoEmisionId] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_OrdenVentas] PRIMARY KEY ([OrdenVentaId]),
    CONSTRAINT [FK_OrdenVentas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([ClienteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrdenVentas_PuntoEmisiones_PuntoEmisionId] FOREIGN KEY ([PuntoEmisionId]) REFERENCES [PuntoEmisiones] ([PuntoEmisionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrdenVentas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoAlmacenes] (
    [ProductoAlmacenId] int NOT NULL IDENTITY,
    [AlmacenId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [SaldoMinimo] decimal(18,2) NOT NULL,
    [SaldoMaximo] decimal(18,2) NULL,
    [Saldo] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoAlmacenes] PRIMARY KEY ([ProductoAlmacenId]),
    CONSTRAINT [FK_ProductoAlmacenes_Almacenes_AlmacenId] FOREIGN KEY ([AlmacenId]) REFERENCES [Almacenes] ([AlmacenId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoAlmacenes_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoAlmacenes_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoColor] (
    [ProductoId] int NOT NULL,
    [ColorId] int NOT NULL,
    CONSTRAINT [PK_ProductoColor] PRIMARY KEY ([ProductoId], [ColorId]),
    CONSTRAINT [FK_ProductoColor_Colores_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [Colores] ([ColorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoColor_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductoPrecios] (
    [ProductoPrecioId] int NOT NULL IDENTITY,
    [ListaPrecioId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [TipoPrecioId] int NOT NULL,
    [PrecioCompra] decimal(18,2) NOT NULL,
    [CantidadMinima] decimal(18,2) NOT NULL,
    [CantidadMaxima] decimal(18,2) NULL,
    [Utilidad] decimal(18,2) NOT NULL,
    [Pvp] decimal(18,2) NOT NULL,
    [ImporteMinimo] decimal(18,2) NULL,
    CONSTRAINT [PK_ProductoPrecios] PRIMARY KEY ([ProductoPrecioId]),
    CONSTRAINT [FK_ProductoPrecios_ListaPrecios_ListaPrecioId] FOREIGN KEY ([ListaPrecioId]) REFERENCES [ListaPrecios] ([ListaPrecioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoPrecios_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoProveedor] (
    [ProductoId] int NOT NULL,
    [ProveedorId] int NOT NULL,
    CONSTRAINT [PK_ProductoProveedor] PRIMARY KEY ([ProductoId], [ProveedorId]),
    CONSTRAINT [FK_ProductoProveedor_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoProveedor_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([ProveedorId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductoRequerimientos] (
    [ProductoRequerimientoId] int NOT NULL IDENTITY,
    [RequerimientoCompraId] int NOT NULL,
    [AreaNegocioId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [MedidaId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoRequerimientos] PRIMARY KEY ([ProductoRequerimientoId]),
    CONSTRAINT [FK_ProductoRequerimientos_AreaNegocios_AreaNegocioId] FOREIGN KEY ([AreaNegocioId]) REFERENCES [AreaNegocios] ([AreaNegocioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoRequerimientos_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoRequerimientos_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoRequerimientos_RequerimientoCompras_RequerimientoCompraId] FOREIGN KEY ([RequerimientoCompraId]) REFERENCES [RequerimientoCompras] ([RequerimientoCompraId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoTalla] (
    [ProductoId] int NOT NULL,
    [TallaId] int NOT NULL,
    CONSTRAINT [PK_ProductoTalla] PRIMARY KEY ([ProductoId], [TallaId]),
    CONSTRAINT [FK_ProductoTalla_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoTalla_Tallas_TallaId] FOREIGN KEY ([TallaId]) REFERENCES [Tallas] ([TallaId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductoTasaImpuesto] (
    [ProductoId] int NOT NULL,
    [TasaImpuestoId] int NOT NULL,
    CONSTRAINT [PK_ProductoTasaImpuesto] PRIMARY KEY ([ProductoId], [TasaImpuestoId]),
    CONSTRAINT [FK_ProductoTasaImpuesto_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoTasaImpuesto_TasaImpuestos_TasaImpuestoId] FOREIGN KEY ([TasaImpuestoId]) REFERENCES [TasaImpuestos] ([TasaImpuestoId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductoOrdenInventarios] (
    [ProductoOrdenInventarioId] int NOT NULL IDENTITY,
    [OrdenInventarioId] int NOT NULL,
    [ConceptoInventarioId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [TipoOperacion] int NOT NULL,
    [AlmacenId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [PrecioUnitario] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoOrdenInventarios] PRIMARY KEY ([ProductoOrdenInventarioId]),
    CONSTRAINT [FK_ProductoOrdenInventarios_Almacenes_AlmacenId] FOREIGN KEY ([AlmacenId]) REFERENCES [Almacenes] ([AlmacenId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOrdenInventarios_ConceptoInventarios_ConceptoInventarioId] FOREIGN KEY ([ConceptoInventarioId]) REFERENCES [ConceptoInventarios] ([ConceptoInventarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOrdenInventarios_OrdenInventarios_OrdenInventarioId] FOREIGN KEY ([OrdenInventarioId]) REFERENCES [OrdenInventarios] ([OrdenInventarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOrdenInventarios_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOrdenInventarios_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [RegistroInventarios] (
    [RegistroInventarioId] int NOT NULL IDENTITY,
    [OperacionMovimientoId] int NOT NULL,
    [TipoRegistroInventario] int NOT NULL,
    [AlmacenId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [FechaOperacion] datetime2 NOT NULL,
    CONSTRAINT [PK_RegistroInventarios] PRIMARY KEY ([RegistroInventarioId]),
    CONSTRAINT [FK_RegistroInventarios_Almacenes_AlmacenId] FOREIGN KEY ([AlmacenId]) REFERENCES [Almacenes] ([AlmacenId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RegistroInventarios_OperacionMovimientos_OperacionMovimientoId] FOREIGN KEY ([OperacionMovimientoId]) REFERENCES [OperacionMovimientos] ([OperacionMovimientoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RegistroInventarios_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [MovimientoCajas] (
    [MovimientoCajaId] int NOT NULL IDENTITY,
    [OperacionId] int NOT NULL,
    [ComprobantePagoId] int NULL,
    [UsuarioId] int NOT NULL,
    [TipoMovimiento] int NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [Concepto] nvarchar(500) NULL,
    [MontoInicial] decimal(18,2) NOT NULL,
    [Ingreso] decimal(18,2) NOT NULL,
    [Egreso] decimal(18,2) NOT NULL,
    [Saldo] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_MovimientoCajas] PRIMARY KEY ([MovimientoCajaId]),
    CONSTRAINT [FK_MovimientoCajas_ComprobantePagos_ComprobantePagoId] FOREIGN KEY ([ComprobantePagoId]) REFERENCES [ComprobantePagos] ([ComprobantePagoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MovimientoCajas_Operaciones_OperacionId] FOREIGN KEY ([OperacionId]) REFERENCES [Operaciones] ([OperacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MovimientoCajas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([UsuarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Recuentos] (
    [RecuentoId] int NOT NULL IDENTITY,
    [OperacionId] int NOT NULL,
    [DenominacionId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Recuentos] PRIMARY KEY ([RecuentoId]),
    CONSTRAINT [FK_Recuentos_Denominaciones_DenominacionId] FOREIGN KEY ([DenominacionId]) REFERENCES [Denominaciones] ([DenominacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Recuentos_Operaciones_OperacionId] FOREIGN KEY ([OperacionId]) REFERENCES [Operaciones] ([OperacionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [DetalleOrdenVentas] (
    [DetalleOrdenVentaId] int NOT NULL IDENTITY,
    [OrdenVentaId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [ProductoPrecioId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [SubTotalIva] decimal(18,2) NOT NULL,
    [SubTotalCero] decimal(18,2) NOT NULL,
    [SubTotalNoObjetoIva] decimal(18,2) NOT NULL,
    [SubTotalExentoIva] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [TotalDescuento] decimal(18,2) NOT NULL,
    [ValorIce] decimal(18,2) NOT NULL,
    [ValorIrbpnr] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_DetalleOrdenVentas] PRIMARY KEY ([DetalleOrdenVentaId]),
    CONSTRAINT [FK_DetalleOrdenVentas_OrdenVentas_OrdenVentaId] FOREIGN KEY ([OrdenVentaId]) REFERENCES [OrdenVentas] ([OrdenVentaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleOrdenVentas_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleOrdenVentas_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleOrdenVentas_ProductoPrecios_ProductoPrecioId] FOREIGN KEY ([ProductoPrecioId]) REFERENCES [ProductoPrecios] ([ProductoPrecioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [HistoricoProductoPrecios] (
    [Id] int NOT NULL IDENTITY,
    [ProductoPrecioId] int NOT NULL,
    [CantidadMinima] decimal(18,2) NOT NULL,
    [CantidadMaxima] decimal(18,2) NOT NULL,
    [TipoPrecioId] int NOT NULL,
    [PrecioCompra] decimal(18,2) NOT NULL,
    [Utilidad] decimal(18,2) NOT NULL,
    [Pvp] decimal(18,2) NOT NULL,
    [FechaUpdate] datetime2 NOT NULL,
    CONSTRAINT [PK_HistoricoProductoPrecios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricoProductoPrecios_ProductoPrecios_ProductoPrecioId] FOREIGN KEY ([ProductoPrecioId]) REFERENCES [ProductoPrecios] ([ProductoPrecioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoCotizaciones] (
    [ProductoCotizacionId] int NOT NULL IDENTITY,
    [SolicitudCotizacionId] int NOT NULL,
    [ProductoRequerimientoId] int NOT NULL,
    [FormaPago] int NOT NULL,
    [ProductoId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [MedidaId] int NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [ValorTasaImpuesto] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    [TotalDescuento] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoCotizaciones] PRIMARY KEY ([ProductoCotizacionId]),
    CONSTRAINT [FK_ProductoCotizaciones_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizaciones_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizaciones_ProductoRequerimientos_ProductoRequerimientoId] FOREIGN KEY ([ProductoRequerimientoId]) REFERENCES [ProductoRequerimientos] ([ProductoRequerimientoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizaciones_SolicitudCotizaciones_SolicitudCotizacionId] FOREIGN KEY ([SolicitudCotizacionId]) REFERENCES [SolicitudCotizaciones] ([SolicitudCotizacionId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoOperacionMovimientos] (
    [Id] int NOT NULL IDENTITY,
    [OperacionMovimientoId] int NOT NULL,
    [ProductoOrdenInventarioId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoOperacionMovimientos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductoOperacionMovimientos_OperacionMovimientos_OperacionMovimientoId] FOREIGN KEY ([OperacionMovimientoId]) REFERENCES [OperacionMovimientos] ([OperacionMovimientoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOperacionMovimientos_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOperacionMovimientos_ProductoOrdenInventarios_ProductoOrdenInventarioId] FOREIGN KEY ([ProductoOrdenInventarioId]) REFERENCES [ProductoOrdenInventarios] ([ProductoOrdenInventarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoRegistroInventarios] (
    [Id] int NOT NULL IDENTITY,
    [RegistroInventarioId] int NOT NULL,
    [ProductoOrdenInventarioId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoRegistroInventarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductoRegistroInventarios_ProductoOrdenInventarios_ProductoOrdenInventarioId] FOREIGN KEY ([ProductoOrdenInventarioId]) REFERENCES [ProductoOrdenInventarios] ([ProductoOrdenInventarioId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoRegistroInventarios_RegistroInventarios_RegistroInventarioId] FOREIGN KEY ([RegistroInventarioId]) REFERENCES [RegistroInventarios] ([RegistroInventarioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [DetalleComprobantePagos] (
    [DetalleComprobantePagoId] int NOT NULL IDENTITY,
    [ComprobantePagoId] int NOT NULL,
    [DetalleOrdenVentaId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [ProductoId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [ProductoPrecioId] int NOT NULL,
    [SubTotalIva] decimal(18,2) NOT NULL,
    [SubTotalCero] decimal(18,2) NOT NULL,
    [SubTotalNoObjetoIva] decimal(18,2) NOT NULL,
    [SubTotalExentoIva] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [TotalDescuento] decimal(18,2) NOT NULL,
    [ValorIce] decimal(18,2) NOT NULL,
    [ValorIrbpnr] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    [Propina] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_DetalleComprobantePagos] PRIMARY KEY ([DetalleComprobantePagoId]),
    CONSTRAINT [FK_DetalleComprobantePagos_ComprobantePagos_ComprobantePagoId] FOREIGN KEY ([ComprobantePagoId]) REFERENCES [ComprobantePagos] ([ComprobantePagoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleComprobantePagos_DetalleOrdenVentas_DetalleOrdenVentaId] FOREIGN KEY ([DetalleOrdenVentaId]) REFERENCES [DetalleOrdenVentas] ([DetalleOrdenVentaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleComprobantePagos_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleComprobantePagos_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleComprobantePagos_ProductoPrecios_ProductoPrecioId] FOREIGN KEY ([ProductoPrecioId]) REFERENCES [ProductoPrecios] ([ProductoPrecioId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoCotizacionProveedores] (
    [ProductoCotizacionProveedorId] int NOT NULL IDENTITY,
    [CotizacionProveedorId] int NOT NULL,
    [ProductoCotizacionId] int NOT NULL,
    [FormaPago] int NOT NULL,
    [ProductoId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [MedidaId] int NOT NULL,
    [PrecioCompra] decimal(18,2) NOT NULL,
    [TasaImpuesto] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoCotizacionProveedores] PRIMARY KEY ([ProductoCotizacionProveedorId]),
    CONSTRAINT [FK_ProductoCotizacionProveedores_CotizacionProveedores_CotizacionProveedorId] FOREIGN KEY ([CotizacionProveedorId]) REFERENCES [CotizacionProveedores] ([CotizacionProveedorId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizacionProveedores_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizacionProveedores_ProductoCotizaciones_ProductoCotizacionId] FOREIGN KEY ([ProductoCotizacionId]) REFERENCES [ProductoCotizaciones] ([ProductoCotizacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCotizacionProveedores_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [MovimientoInventarios] (
    [MovimientoInventarioId] int NOT NULL IDENTITY,
    [ProductoAlmacenId] int NOT NULL,
    [ProductoOperacionMovimientoId] int NOT NULL,
    [ProductoRegistroInventarioId] int NOT NULL,
    [FechaOperacionInventario] datetime2 NOT NULL,
    [CantidadSaldoInicial] decimal(18,2) NOT NULL,
    [CostoUnitarioSaldoInicial] decimal(18,2) NOT NULL,
    [CostoTotalSaldoInical] decimal(18,2) NOT NULL,
    [CantidadEntrada] decimal(18,2) NOT NULL,
    [CostoUnitarioEntrada] decimal(18,2) NOT NULL,
    [CostoTotalEntrada] decimal(18,2) NOT NULL,
    [CantidadSalida] decimal(18,2) NOT NULL,
    [CostoUnitarioSalida] decimal(18,2) NOT NULL,
    [CostoTotalSalida] decimal(18,2) NOT NULL,
    [CantidadSaldoFinal] decimal(18,2) NOT NULL,
    [CostoUnitarioSaldoFinal] decimal(18,2) NOT NULL,
    [CostoTotalSaldoFinal] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_MovimientoInventarios] PRIMARY KEY ([MovimientoInventarioId]),
    CONSTRAINT [FK_MovimientoInventarios_ProductoAlmacenes_ProductoAlmacenId] FOREIGN KEY ([ProductoAlmacenId]) REFERENCES [ProductoAlmacenes] ([ProductoAlmacenId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MovimientoInventarios_ProductoOperacionMovimientos_ProductoOperacionMovimientoId] FOREIGN KEY ([ProductoOperacionMovimientoId]) REFERENCES [ProductoOperacionMovimientos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MovimientoInventarios_ProductoRegistroInventarios_ProductoRegistroInventarioId] FOREIGN KEY ([ProductoRegistroInventarioId]) REFERENCES [ProductoRegistroInventarios] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ImpuestoVentas] (
    [ImpuestoVentaId] int NOT NULL IDENTITY,
    [DetalleComprobantePagoId] int NOT NULL,
    [TasaImpuestoId] int NOT NULL,
    CONSTRAINT [PK_ImpuestoVentas] PRIMARY KEY ([ImpuestoVentaId]),
    CONSTRAINT [FK_ImpuestoVentas_DetalleComprobantePagos_DetalleComprobantePagoId] FOREIGN KEY ([DetalleComprobantePagoId]) REFERENCES [DetalleComprobantePagos] ([DetalleComprobantePagoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ImpuestoVentas_TasaImpuestos_TasaImpuestoId] FOREIGN KEY ([TasaImpuestoId]) REFERENCES [TasaImpuestos] ([TasaImpuestoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoOrdenCompras] (
    [ProductoOrdenCompraId] int NOT NULL IDENTITY,
    [OrdenCompraId] int NOT NULL,
    [ProductoCotizacionProveedorId] int NOT NULL,
    [Impuesto] int NOT NULL,
    [ProductoId] int NOT NULL,
    [MedidaId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [PrecioUnitario] decimal(18,2) NOT NULL,
    [SubTotalIva] decimal(18,2) NOT NULL,
    [SubTotalCero] decimal(18,2) NOT NULL,
    [SubTotalNoObjetoIva] decimal(18,2) NOT NULL,
    [SubTotalExcentoIva] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [TotalDescuento] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoOrdenCompras] PRIMARY KEY ([ProductoOrdenCompraId]),
    CONSTRAINT [FK_ProductoOrdenCompras_Medidas_MedidaId] FOREIGN KEY ([MedidaId]) REFERENCES [Medidas] ([MedidaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoOrdenCompras_OrdenCompras_OrdenCompraId] FOREIGN KEY ([OrdenCompraId]) REFERENCES [OrdenCompras] ([OrdenCompraId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoOrdenCompras_ProductoCotizacionProveedores_ProductoCotizacionProveedorId] FOREIGN KEY ([ProductoCotizacionProveedorId]) REFERENCES [ProductoCotizacionProveedores] ([ProductoCotizacionProveedorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductoOrdenCompras_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ProductoCompras] (
    [ProductoCompraId] int NOT NULL IDENTITY,
    [CompraId] int NOT NULL,
    [ProductoOrdenCompraId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [PresentacionId] int NOT NULL,
    [Cantidad] decimal(18,2) NOT NULL,
    [PrecioCompra] decimal(18,2) NOT NULL,
    [SubTotalIva] decimal(18,2) NOT NULL,
    [SubTotalCero] decimal(18,2) NOT NULL,
    [SubTotalNoObjetoIva] decimal(18,2) NOT NULL,
    [SubTotalExentoIva] decimal(18,2) NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [TotalDescuento] decimal(18,2) NOT NULL,
    [ValorIce] decimal(18,2) NOT NULL,
    [ValorIrbpnr] decimal(18,2) NOT NULL,
    [ValorIva] decimal(18,2) NOT NULL,
    [Propina] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProductoCompras] PRIMARY KEY ([ProductoCompraId]),
    CONSTRAINT [FK_ProductoCompras_Compras_CompraId] FOREIGN KEY ([CompraId]) REFERENCES [Compras] ([CompraId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCompras_Presentaciones_PresentacionId] FOREIGN KEY ([PresentacionId]) REFERENCES [Presentaciones] ([PresentacionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCompras_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([ProductoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductoCompras_ProductoOrdenCompras_ProductoOrdenCompraId] FOREIGN KEY ([ProductoOrdenCompraId]) REFERENCES [ProductoOrdenCompras] ([ProductoOrdenCompraId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Almacenes_EstablecimientoId] ON [Almacenes] ([EstablecimientoId]);

GO

CREATE INDEX [IX_Clientes_TipoIdentificacionId] ON [Clientes] ([TipoIdentificacionId]);

GO

CREATE INDEX [IX_Compras_ProveedorId] ON [Compras] ([ProveedorId]);

GO

CREATE INDEX [IX_Compras_UsuarioId] ON [Compras] ([UsuarioId]);

GO

CREATE INDEX [IX_ComprobantePagos_ClienteId] ON [ComprobantePagos] ([ClienteId]);

GO

CREATE INDEX [IX_ComprobantePagos_ComprobanteId] ON [ComprobantePagos] ([ComprobanteId]);

GO

CREATE INDEX [IX_ComprobantePagos_EstadoCe] ON [ComprobantePagos] ([EstadoCe]);

GO

CREATE INDEX [IX_ComprobantePagos_FormaPagoId] ON [ComprobantePagos] ([FormaPagoId]);

GO

CREATE INDEX [IX_ComprobantePagos_PuntoEmisionId] ON [ComprobantePagos] ([PuntoEmisionId]);

GO

CREATE INDEX [IX_ComprobantePagos_TipoIdentificacionId] ON [ComprobantePagos] ([TipoIdentificacionId]);

GO

CREATE INDEX [IX_ComprobantePagos_UsuarioId] ON [ComprobantePagos] ([UsuarioId]);

GO

CREATE INDEX [IX_ComprobanteTipoIdentificacion_TipoIdentificacionId] ON [ComprobanteTipoIdentificacion] ([TipoIdentificacionId]);

GO

CREATE INDEX [IX_CotizacionProveedores_ProveedorId] ON [CotizacionProveedores] ([ProveedorId]);

GO

CREATE INDEX [IX_DetalleComprobantePagos_ComprobantePagoId] ON [DetalleComprobantePagos] ([ComprobantePagoId]);

GO

CREATE INDEX [IX_DetalleComprobantePagos_DetalleOrdenVentaId] ON [DetalleComprobantePagos] ([DetalleOrdenVentaId]);

GO

CREATE INDEX [IX_DetalleComprobantePagos_PresentacionId] ON [DetalleComprobantePagos] ([PresentacionId]);

GO

CREATE INDEX [IX_DetalleComprobantePagos_ProductoId] ON [DetalleComprobantePagos] ([ProductoId]);

GO

CREATE INDEX [IX_DetalleComprobantePagos_ProductoPrecioId] ON [DetalleComprobantePagos] ([ProductoPrecioId]);

GO

CREATE INDEX [IX_DetalleOrdenVentas_OrdenVentaId] ON [DetalleOrdenVentas] ([OrdenVentaId]);

GO

CREATE INDEX [IX_DetalleOrdenVentas_PresentacionId] ON [DetalleOrdenVentas] ([PresentacionId]);

GO

CREATE INDEX [IX_DetalleOrdenVentas_ProductoId] ON [DetalleOrdenVentas] ([ProductoId]);

GO

CREATE INDEX [IX_DetalleOrdenVentas_ProductoPrecioId] ON [DetalleOrdenVentas] ([ProductoPrecioId]);

GO

CREATE INDEX [IX_Establecimientos_EmpresaId] ON [Establecimientos] ([EmpresaId]);

GO

CREATE INDEX [IX_HistoricoProductoPrecios_ProductoPrecioId] ON [HistoricoProductoPrecios] ([ProductoPrecioId]);

GO

CREATE INDEX [IX_ImpuestoVentas_DetalleComprobantePagoId] ON [ImpuestoVentas] ([DetalleComprobantePagoId]);

GO

CREATE INDEX [IX_ImpuestoVentas_TasaImpuestoId] ON [ImpuestoVentas] ([TasaImpuestoId]);

GO

CREATE INDEX [IX_MovimientoCajas_ComprobantePagoId] ON [MovimientoCajas] ([ComprobantePagoId]);

GO

CREATE INDEX [IX_MovimientoCajas_OperacionId] ON [MovimientoCajas] ([OperacionId]);

GO

CREATE INDEX [IX_MovimientoCajas_UsuarioId] ON [MovimientoCajas] ([UsuarioId]);

GO

CREATE INDEX [IX_MovimientoInventarios_ProductoAlmacenId] ON [MovimientoInventarios] ([ProductoAlmacenId]);

GO

CREATE INDEX [IX_MovimientoInventarios_ProductoOperacionMovimientoId] ON [MovimientoInventarios] ([ProductoOperacionMovimientoId]);

GO

CREATE INDEX [IX_MovimientoInventarios_ProductoRegistroInventarioId] ON [MovimientoInventarios] ([ProductoRegistroInventarioId]);

GO

CREATE INDEX [IX_NumeradorComprobantes_ComprobanteId] ON [NumeradorComprobantes] ([ComprobanteId]);

GO

CREATE INDEX [IX_NumeradorComprobantes_PuntoEmisionId] ON [NumeradorComprobantes] ([PuntoEmisionId]);

GO

CREATE INDEX [IX_NumeradorOrdenVentas_PuntoEmisionId] ON [NumeradorOrdenVentas] ([PuntoEmisionId]);

GO

CREATE INDEX [IX_Operaciones_PuntoEmisionId] ON [Operaciones] ([PuntoEmisionId]);

GO

CREATE INDEX [IX_OperacionMovimientos_AlmacenId] ON [OperacionMovimientos] ([AlmacenId]);

GO

CREATE INDEX [IX_OrdenCompras_ProveedorId] ON [OrdenCompras] ([ProveedorId]);

GO

CREATE INDEX [IX_OrdenCompras_UsuarioId] ON [OrdenCompras] ([UsuarioId]);

GO

CREATE INDEX [IX_OrdenInventarios_UsuarioId] ON [OrdenInventarios] ([UsuarioId]);

GO

CREATE INDEX [IX_OrdenVentas_ClienteId] ON [OrdenVentas] ([ClienteId]);

GO

CREATE INDEX [IX_OrdenVentas_PuntoEmisionId] ON [OrdenVentas] ([PuntoEmisionId]);

GO

CREATE INDEX [IX_OrdenVentas_UsuarioId] ON [OrdenVentas] ([UsuarioId]);

GO

CREATE INDEX [IX_Presentaciones_MedidaId] ON [Presentaciones] ([MedidaId]);

GO

CREATE INDEX [IX_ProductoAlmacenes_AlmacenId] ON [ProductoAlmacenes] ([AlmacenId]);

GO

CREATE INDEX [IX_ProductoAlmacenes_PresentacionId] ON [ProductoAlmacenes] ([PresentacionId]);

GO

CREATE INDEX [IX_ProductoAlmacenes_ProductoId] ON [ProductoAlmacenes] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoColor_ColorId] ON [ProductoColor] ([ColorId]);

GO

CREATE INDEX [IX_ProductoCompras_CompraId] ON [ProductoCompras] ([CompraId]);

GO

CREATE INDEX [IX_ProductoCompras_PresentacionId] ON [ProductoCompras] ([PresentacionId]);

GO

CREATE INDEX [IX_ProductoCompras_ProductoId] ON [ProductoCompras] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoCompras_ProductoOrdenCompraId] ON [ProductoCompras] ([ProductoOrdenCompraId]);

GO

CREATE INDEX [IX_ProductoCotizaciones_MedidaId] ON [ProductoCotizaciones] ([MedidaId]);

GO

CREATE INDEX [IX_ProductoCotizaciones_ProductoId] ON [ProductoCotizaciones] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoCotizaciones_ProductoRequerimientoId] ON [ProductoCotizaciones] ([ProductoRequerimientoId]);

GO

CREATE INDEX [IX_ProductoCotizaciones_SolicitudCotizacionId] ON [ProductoCotizaciones] ([SolicitudCotizacionId]);

GO

CREATE INDEX [IX_ProductoCotizacionProveedores_CotizacionProveedorId] ON [ProductoCotizacionProveedores] ([CotizacionProveedorId]);

GO

CREATE INDEX [IX_ProductoCotizacionProveedores_MedidaId] ON [ProductoCotizacionProveedores] ([MedidaId]);

GO

CREATE INDEX [IX_ProductoCotizacionProveedores_ProductoCotizacionId] ON [ProductoCotizacionProveedores] ([ProductoCotizacionId]);

GO

CREATE INDEX [IX_ProductoCotizacionProveedores_ProductoId] ON [ProductoCotizacionProveedores] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoOperacionMovimientos_OperacionMovimientoId] ON [ProductoOperacionMovimientos] ([OperacionMovimientoId]);

GO

CREATE INDEX [IX_ProductoOperacionMovimientos_PresentacionId] ON [ProductoOperacionMovimientos] ([PresentacionId]);

GO

CREATE INDEX [IX_ProductoOperacionMovimientos_ProductoOrdenInventarioId] ON [ProductoOperacionMovimientos] ([ProductoOrdenInventarioId]);

GO

CREATE INDEX [IX_ProductoOrdenCompras_MedidaId] ON [ProductoOrdenCompras] ([MedidaId]);

GO

CREATE INDEX [IX_ProductoOrdenCompras_OrdenCompraId] ON [ProductoOrdenCompras] ([OrdenCompraId]);

GO

CREATE INDEX [IX_ProductoOrdenCompras_ProductoCotizacionProveedorId] ON [ProductoOrdenCompras] ([ProductoCotizacionProveedorId]);

GO

CREATE INDEX [IX_ProductoOrdenCompras_ProductoId] ON [ProductoOrdenCompras] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoOrdenInventarios_AlmacenId] ON [ProductoOrdenInventarios] ([AlmacenId]);

GO

CREATE INDEX [IX_ProductoOrdenInventarios_ConceptoInventarioId] ON [ProductoOrdenInventarios] ([ConceptoInventarioId]);

GO

CREATE INDEX [IX_ProductoOrdenInventarios_OrdenInventarioId] ON [ProductoOrdenInventarios] ([OrdenInventarioId]);

GO

CREATE INDEX [IX_ProductoOrdenInventarios_PresentacionId] ON [ProductoOrdenInventarios] ([PresentacionId]);

GO

CREATE INDEX [IX_ProductoOrdenInventarios_ProductoId] ON [ProductoOrdenInventarios] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoPrecios_ListaPrecioId] ON [ProductoPrecios] ([ListaPrecioId]);

GO

CREATE INDEX [IX_ProductoPrecios_ProductoId] ON [ProductoPrecios] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoProveedor_ProveedorId] ON [ProductoProveedor] ([ProveedorId]);

GO

CREATE INDEX [IX_ProductoRegistroInventarios_ProductoOrdenInventarioId] ON [ProductoRegistroInventarios] ([ProductoOrdenInventarioId]);

GO

CREATE INDEX [IX_ProductoRegistroInventarios_RegistroInventarioId] ON [ProductoRegistroInventarios] ([RegistroInventarioId]);

GO

CREATE INDEX [IX_ProductoRequerimientos_AreaNegocioId] ON [ProductoRequerimientos] ([AreaNegocioId]);

GO

CREATE INDEX [IX_ProductoRequerimientos_MedidaId] ON [ProductoRequerimientos] ([MedidaId]);

GO

CREATE INDEX [IX_ProductoRequerimientos_ProductoId] ON [ProductoRequerimientos] ([ProductoId]);

GO

CREATE INDEX [IX_ProductoRequerimientos_RequerimientoCompraId] ON [ProductoRequerimientos] ([RequerimientoCompraId]);

GO

CREATE INDEX [IX_Productos_CategoriaId] ON [Productos] ([CategoriaId]);

GO

CREATE INDEX [IX_Productos_LaboratorioId] ON [Productos] ([LaboratorioId]);

GO

CREATE INDEX [IX_Productos_MarcaId] ON [Productos] ([MarcaId]);

GO

CREATE INDEX [IX_Productos_MedidaId] ON [Productos] ([MedidaId]);

GO

CREATE INDEX [IX_Productos_MonedaId] ON [Productos] ([MonedaId]);

GO

CREATE INDEX [IX_Productos_PresentacionId] ON [Productos] ([PresentacionId]);

GO

CREATE INDEX [IX_Productos_SubCategoriaId] ON [Productos] ([SubCategoriaId]);

GO

CREATE INDEX [IX_Productos_TallaId] ON [Productos] ([TallaId]);

GO

CREATE INDEX [IX_ProductoTalla_TallaId] ON [ProductoTalla] ([TallaId]);

GO

CREATE INDEX [IX_ProductoTasaImpuesto_TasaImpuestoId] ON [ProductoTasaImpuesto] ([TasaImpuestoId]);

GO

CREATE INDEX [IX_Proveedores_TipoIdentificacionId] ON [Proveedores] ([TipoIdentificacionId]);

GO

CREATE INDEX [IX_Proveedores_UbigeoId] ON [Proveedores] ([UbigeoId]);

GO

CREATE INDEX [IX_PuntoEmisiones_EstablecimientoId] ON [PuntoEmisiones] ([EstablecimientoId]);

GO

CREATE INDEX [IX_Recuentos_DenominacionId] ON [Recuentos] ([DenominacionId]);

GO

CREATE INDEX [IX_Recuentos_OperacionId] ON [Recuentos] ([OperacionId]);

GO

CREATE INDEX [IX_RegistroInventarios_AlmacenId] ON [RegistroInventarios] ([AlmacenId]);

GO

CREATE INDEX [IX_RegistroInventarios_OperacionMovimientoId] ON [RegistroInventarios] ([OperacionMovimientoId]);

GO

CREATE INDEX [IX_RegistroInventarios_UsuarioId] ON [RegistroInventarios] ([UsuarioId]);

GO

CREATE INDEX [IX_RolFuncion_FuncionId] ON [RolFuncion] ([FuncionId]);

GO

CREATE INDEX [IX_SolicitudCotizaciones_ProveedorId] ON [SolicitudCotizaciones] ([ProveedorId]);

GO

CREATE INDEX [IX_SubCategorias_CategoriaId] ON [SubCategorias] ([CategoriaId]);

GO

CREATE INDEX [IX_TasaImpuestos_ImpuestoId] ON [TasaImpuestos] ([ImpuestoId]);

GO

CREATE INDEX [IX_Usuarios_RolId] ON [Usuarios] ([RolId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200730151844_init', N'3.1.5');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200730193207_initBusinessScript', N'3.1.5');

GO

