
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/01/2019 14:48:36
-- Generated from EDMX file: C:\Users\danvi\Documents\Repositorios Git\MantenedorCRUD\Models\ModelEmpleadosBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EmpleadosBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Empleado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleado];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [rut] varchar(50)  NOT NULL,
    [pass] varchar(50)  NOT NULL
);
GO

-- Creating table 'Empleado'
CREATE TABLE [dbo].[Empleado] (
    [EmpleadoID] int  NOT NULL,
    [rut] varchar(12)  NOT NULL,
    [pnombre] varchar(25)  NOT NULL,
    [apaterno] varchar(25)  NOT NULL,
    [amaterno] varchar(25)  NOT NULL,
    [annos_xp] int  NOT NULL,
    [genero] varchar(10)  NOT NULL,
    [fec_nac] datetime  NOT NULL,
    [email] varchar(30)  NOT NULL,
    [telefono] varchar(15)  NOT NULL,
    [direccion] varchar(40)  NOT NULL,
    [n_profesion] varchar(25)  NOT NULL,
    [foto] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [rut] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([rut] ASC);
GO

-- Creating primary key on [EmpleadoID] in table 'Empleado'
ALTER TABLE [dbo].[Empleado]
ADD CONSTRAINT [PK_Empleado]
    PRIMARY KEY CLUSTERED ([EmpleadoID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------