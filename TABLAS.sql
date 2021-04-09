/*
 Navicat Premium Data Transfer

 Source Server         : mia
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : DESKTOP-U4IFPH3:1433
 Source Catalog        : proyecto
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 09/04/2021 08:36:12
*/


-- ----------------------------
-- Table structure for Actividades
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Actividades]') AND type IN ('U'))
	DROP TABLE [dbo].[Actividades]
GO

CREATE TABLE [dbo].[Actividades] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Duracion_llamada] varchar(50) COLLATE Modern_Spanish_CI_AS  NULL,
  [Descripcion] varchar(150) COLLATE Modern_Spanish_CI_AS  NULL,
  [Fecha] varchar(25) COLLATE Modern_Spanish_CI_AS  NULL,
  [Tipo] varchar(25) COLLATE Modern_Spanish_CI_AS  NULL,
  [Resolvio] varchar(30) COLLATE Modern_Spanish_CI_AS  NULL,
  [IdUsuario] int  NULL
)
GO

ALTER TABLE [dbo].[Actividades] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Actividades
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[Actividades] ON
GO

SET IDENTITY_INSERT [dbo].[Actividades] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for Roles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type IN ('U'))
	DROP TABLE [dbo].[Roles]
GO

CREATE TABLE [dbo].[Roles] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Descripcion] varchar(50) COLLATE Modern_Spanish_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Roles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Roles
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[Roles] ON
GO

INSERT INTO [dbo].[Roles] ([Id], [Descripcion]) VALUES (N'1', N'Supervisor'), (N'2', N'Agente')
GO

SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for UsuarioRol
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioRol]') AND type IN ('U'))
	DROP TABLE [dbo].[UsuarioRol]
GO

CREATE TABLE [dbo].[UsuarioRol] (
  [IdUsuario] int  NOT NULL,
  [IdRol] int  NOT NULL
)
GO

ALTER TABLE [dbo].[UsuarioRol] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of UsuarioRol
-- ----------------------------
BEGIN TRANSACTION
GO

INSERT INTO [dbo].[UsuarioRol] VALUES (N'1', N'1')
GO

COMMIT
GO


-- ----------------------------
-- Table structure for Usuarios
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type IN ('U'))
	DROP TABLE [dbo].[Usuarios]
GO

CREATE TABLE [dbo].[Usuarios] (
  [IdUsuario] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(50) COLLATE Modern_Spanish_CI_AS  NULL,
  [Sal] nvarchar(500) COLLATE Modern_Spanish_CI_AS  NULL,
  [Clave] nvarchar(500) COLLATE Modern_Spanish_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Usuarios] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Usuarios
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[Usuarios] ON
GO

INSERT INTO [dbo].[Usuarios] ([IdUsuario], [Nombre], [Sal], [Clave]) VALUES (N'1', N'supervisor', N'VyKCpBRTAQh1FU4JkgJwCg==', N'XtSvkmrWO/MG2eFhKcWLP1I5jwahyiK2nynl7StrkZY=')
GO

SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO

COMMIT
GO


-- ----------------------------
-- Auto increment value for Actividades
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Actividades]', RESEED, 1)
GO


-- ----------------------------
-- Auto increment value for Roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Roles]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table Roles
-- ----------------------------
ALTER TABLE [dbo].[Roles] ADD CONSTRAINT [PK__Roles__3214EC07A004F700] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table UsuarioRol
-- ----------------------------
ALTER TABLE [dbo].[UsuarioRol] ADD CONSTRAINT [PK__UsuarioR__89C12A13345701A1] PRIMARY KEY CLUSTERED ([IdUsuario], [IdRol])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Usuarios
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Usuarios]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Usuarios
-- ----------------------------
ALTER TABLE [dbo].[Usuarios] ADD CONSTRAINT [PK__Usuarios__5B65BF9793D1A1EB] PRIMARY KEY CLUSTERED ([IdUsuario])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table UsuarioRol
-- ----------------------------
ALTER TABLE [dbo].[UsuarioRol] ADD CONSTRAINT [FK__UsuarioRo__IdUsu__3B75D760] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([IdUsuario]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[UsuarioRol] ADD CONSTRAINT [FK__UsuarioRo__IdRol__3C69FB99] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

