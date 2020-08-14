IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Inquilinos] (
    [InquilinoId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NULL,
    [Dominio] nvarchar(500) NULL,
    [PlanServicio] nvarchar(200) NULL,
    [FechaCreacion] datetime2 NOT NULL,
    [FechaInicio] datetime2 NOT NULL,
    [FechaFin] datetime2 NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Inquilinos] PRIMARY KEY ([InquilinoId])
);

GO

CREATE TABLE [Servidores] (
    [ServidorId] int NOT NULL IDENTITY,
    [Nombre] nvarchar(200) NULL,
    [Ubicacion] nvarchar(200) NULL,
    [Estado] nvarchar(200) NULL,
    CONSTRAINT [PK_Servidores] PRIMARY KEY ([ServidorId])
);

GO

CREATE TABLE [BaseDatos] (
    [BaseDatoId] int NOT NULL IDENTITY,
    [ServidorId] int NOT NULL,
    [BaseDatoOfInquilinoId] int NOT NULL,
    [Nombre] nvarchar(100) NULL,
    [DatabaseConnectionString] nvarchar(300) NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_BaseDatos] PRIMARY KEY ([BaseDatoId]),
    CONSTRAINT [FK_BaseDatos_Inquilinos_BaseDatoOfInquilinoId] FOREIGN KEY ([BaseDatoOfInquilinoId]) REFERENCES [Inquilinos] ([InquilinoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_BaseDatos_Servidores_ServidorId] FOREIGN KEY ([ServidorId]) REFERENCES [Servidores] ([ServidorId]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_BaseDatos_BaseDatoOfInquilinoId] ON [BaseDatos] ([BaseDatoOfInquilinoId]);

GO

CREATE INDEX [IX_BaseDatos_ServidorId] ON [BaseDatos] ([ServidorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200730161642_initCatalogo', N'3.1.5');

GO

