
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2018 20:56:58
-- Generated from EDMX file: C:\Users\Alex\source\repos\Tests\MIR\EF6\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mir];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[METERINGS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[METERINGS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'METERINGS'
CREATE TABLE [dbo].[METERINGS] (
    [IDOBJECT] int  NOT NULL,
    [IDTYPE_OBJECT] int  NOT NULL,
    [TIME_BEGIN] datetime  NOT NULL,
    [TIME_END] datetime  NOT NULL,
    [IDOBJECT_AGGREGATE] int  NOT NULL,
    [IDOBJECT_AVERAGE] int  NOT NULL,
    [STATUS] int  NULL,
    [VALUE_METERING] float  NOT NULL,
    [TIME_INSERT] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDOBJECT], [IDTYPE_OBJECT], [TIME_END], [IDOBJECT_AGGREGATE], [IDOBJECT_AVERAGE] in table 'METERINGS'
ALTER TABLE [dbo].[METERINGS]
ADD CONSTRAINT [PK_METERINGS]
    PRIMARY KEY CLUSTERED ([IDOBJECT], [IDTYPE_OBJECT], [TIME_END], [IDOBJECT_AGGREGATE], [IDOBJECT_AVERAGE] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------