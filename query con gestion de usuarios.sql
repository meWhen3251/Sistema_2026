USE [master] -- usa la base de datos "master" para ejecutar el query
GO

-- pregunta si la base de datos ya existe y sino la crea
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Sistema_2026')
    CREATE DATABASE [Sistema_2026];
GO

USE [Sistema_2026] -- ahora cambia para que el resto del query sea en el sistema mismo
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

--  setup de la base de datos
ALTER DATABASE [Sistema_2026] SET 
    RECOVERY FULL, 
    PAGE_VERIFY CHECKSUM, 
    QUERY_STORE = ON;
GO


--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- TABLAS FUERTES
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

-- Contraseñas
CREATE TABLE [dbo].[Contrasenas](
    [ID_Pass] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [contrasena] NVARCHAR(64) NOT NULL,
    [fecha_creacion] [date] NOT NULL
);


-- Familia
CREATE TABLE [dbo].[Familia](
    [ID_Familia] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Nombre] [nchar](25) NOT NULL,
    [Desc] [nchar](50) NULL
);


-- Personas
CREATE TABLE [dbo].[Personas](
    [ID_Persona] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Nombre] [nchar](40) NOT NULL,
    [Apellido] [nchar](40) NOT NULL,
    [Correo] [nchar](50) NOT NULL
);


-- Preguntas de seguridad
CREATE TABLE [dbo].[PSeguridad](
    [ID_Pregunta] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Pregunta] [nchar](40) NOT NULL,
    [Habilitada] [bit] NOT NULL
);


-- Roles
CREATE TABLE [dbo].[Roles](
    [ID_Rol] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [nchar](30) NOT NULL,
    [Descripcion] [nchar](50) NULL
);

-- Configuraciones del sistema
CREATE TABLE [dbo].[Configuraciones](
    [ID_Configuracion] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Accion] [nchar](25) NOT NULL,
    [Valor] [nchar](30) NOT NULL
);

--Permisos de usuarios
CREATE TABLE [dbo].[Permisos](
    [ID_Permiso] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Permiso] [nchar](25) NOT NULL,
    [Descripcion] [nchar](50) NULL
);

--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- TABLAS DÉBILES QUE TIENEN AL MENOS 1 CLAVE FORÁNEA
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

-- Usuarios
CREATE TABLE [dbo].[Usuarios](
    [ID_Usuario] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [nvarchar](50) NOT NULL,
    [ID_Persona] [int] NOT NULL,
    [ID_Clave] [int] NOT NULL,
    CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([ID_Persona]) REFERENCES [dbo].[Personas]([ID_Persona])
);


-- Respuestas de seguridad
CREATE TABLE [dbo].[RSeguridad](
    [ID_Respuesta] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ID_Pregunta] [int] NOT NULL,
    [Respuesta] [nchar](45) NOT NULL,
    CONSTRAINT [FK_RSeguridad_PSeguridad] FOREIGN KEY([ID_Pregunta]) REFERENCES [dbo].[PSeguridad]([ID_Pregunta])
);

--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- TABLAS COMPUESTAS
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

-- Familia_Compuesta, relacionando familias con roles
CREATE TABLE [dbo].[Familia_Comp](
    [ID_Familia] [int] NOT NULL,
    [ID_Rol] [int] NOT NULL,
    [desc] [nchar](50) NULL,
    CONSTRAINT [PK_Familia_Comp] PRIMARY KEY ([ID_Familia], [ID_Rol]),
    CONSTRAINT [FK_Familia_Comp_Familia] FOREIGN KEY([ID_Familia]) REFERENCES [dbo].[Familia]([ID_Familia]),
    CONSTRAINT [FK_Familia_Comp_Roles] FOREIGN KEY([ID_Rol]) REFERENCES [dbo].[Roles]([ID_Rol])
);


-- FamiliaUsuarios_Compuesta, que permite otorgar todos los permisos que recaen en una familia a un usuario
CREATE TABLE [dbo].[FamiliaUsuarios_Comp](
    [ID_Familia] [int] NOT NULL,
    [ID_Usuario] [int] NOT NULL,
    [razon] [nchar](40) NULL,
    CONSTRAINT [PK_FamiliaUsuarios_Comp] PRIMARY KEY ([ID_Familia], [ID_Usuario]),
    CONSTRAINT [FK_FamiliaUsuarios_Comp_Familia] FOREIGN KEY([ID_Familia]) REFERENCES [dbo].[Familia]([ID_Familia]),
    CONSTRAINT [FK_FamiliaUsuarios_Comp_Usuarios] FOREIGN KEY([ID_Usuario]) REFERENCES [dbo].[Usuarios]([ID_Usuario])
);

--FamiliaPermisos_Compuesta, que permite otorgar todos los permisos que recaen en una familia a un permiso
CREATE TABLE [dbo].[FamiliaPermisos_Comp](
    [ID_Familia] [int] NOT NULL,
    [ID_Permiso] [int] NOT NULL,
    [razon] [nchar](40) NULL,
    CONSTRAINT [PK_FamiliaPermisos_Comp] PRIMARY KEY ([ID_Familia], [ID_Permiso]),
    CONSTRAINT [FK_FamiliaPermisos_Comp_Familia] FOREIGN KEY([ID_Familia]) REFERENCES [dbo].[Familia]([ID_Familia]),
    CONSTRAINT [FK_FamiliaPermisos_Comp_Permisos] FOREIGN KEY([ID_Permiso]) REFERENCES [dbo].[Permisos]([ID_Permiso])
);

-- Histórico de contraseñas, que permite tener un log de las contraseñas que tiene cada usuario
CREATE TABLE [dbo].[Historico_Contrasenas](
    [ID_Usuario] [int] NOT NULL,
    [ID_Pass] [int] NOT NULL,
    [Activo] [bit] NULL,
    CONSTRAINT [PK_Historico_Contrasenas] PRIMARY KEY ([ID_Usuario], [ID_Pass]),
    CONSTRAINT [FK_Historico_Contrasenas_Contrasenas] FOREIGN KEY([ID_Pass]) REFERENCES [dbo].[Contrasenas]([ID_Pass]),
    CONSTRAINT [FK_Historico_Contrasenas_Usuarios] FOREIGN KEY([ID_Usuario]) REFERENCES [dbo].[Usuarios]([ID_Usuario])
);


-- RolesUsuarios_Compuesta, que permite otorgar roles a usuarios
CREATE TABLE [dbo].[RolesUsuarios_Comp](
    [ID_Rol] [int] NOT NULL,
    [ID_Usuario] [int] NOT NULL,
    [razon] [nchar](40) NULL,
    CONSTRAINT [PK_RolesUsuarios_Comp] PRIMARY KEY ([ID_Rol], [ID_Usuario]),
    CONSTRAINT [FK_RolesUsuarios_Comp_Roles] FOREIGN KEY([ID_Rol]) REFERENCES [dbo].[Roles]([ID_Rol]),
    CONSTRAINT [FK_RolesUsuarios_Comp_Usuarios] FOREIGN KEY([ID_Usuario]) REFERENCES [dbo].[Usuarios]([ID_Usuario])
);

--PermisosRoles_Compuesta, que permite otorgar permisos a roles
CREATE TABLE [dbo].[PermisosRoles_Comp](
    [ID_Permiso] [int] NOT NULL,
    [ID_Rol] [int] NOT NULL,
    [razon] [nchar](40) NULL,
    CONSTRAINT [PK_PermisosRoles_Comp] PRIMARY KEY ([ID_Permiso], [ID_Rol]),
    CONSTRAINT [FK_PermisosRoles_Comp_Permisos] FOREIGN KEY([ID_Permiso]) REFERENCES [dbo].[Permisos]([ID_Permiso]),
    CONSTRAINT [FK_PermisosRoles_Comp_Roles] FOREIGN KEY([ID_Rol]) REFERENCES [dbo].[Roles]([ID_Rol])
);

--PermisosUsuarios_Compuesta, que permite dar permisos a usuarios
CREATE TABLE [dbo].[PermisosUsuarios_Comp](
    [ID_Permiso] [int] NOT NULL,
    [ID_Usuario] [int] NOT NULL,
    [razon] [nchar](40) NULL,
    CONSTRAINT [PK_PermisosUsuarios_Comp] PRIMARY KEY ([ID_Permiso], [ID_Usuario]),
    CONSTRAINT [FK_PermisosUsuarios_Comp_Permisos] FOREIGN KEY([ID_Permiso]) REFERENCES [dbo].[Permisos]([ID_Permiso]),
    CONSTRAINT [FK_PermisosUsuarios_Comp_Usuarios] FOREIGN KEY([ID_Usuario]) REFERENCES [dbo].[Usuarios]([ID_Usuario])
);

--Respuestas de seguridad de usuarios, conecta respuestas de las preguntas con el usuario que respondió
CREATE TABLE [dbo].[RSeguridadUsuarios_Comp](
    [ID_Respuesta] [int] NOT NULL,
    [ID_Usuario] [int] NOT NULL,
    [desc] [nchar](40) NULL,
    CONSTRAINT [PK_RSeguridadUsuarios_Comp] PRIMARY KEY ([ID_Respuesta], [ID_Usuario]),
    CONSTRAINT [FK_RSeguridadUsuarios_Comp_RSeguridad] FOREIGN KEY([ID_Respuesta]) REFERENCES [dbo].[RSeguridad]([ID_Respuesta]),
    CONSTRAINT [FK_RSeguridadUsuarios_Comp_Usuarios] FOREIGN KEY([ID_Usuario]) REFERENCES [dbo].[Usuarios]([ID_Usuario])
);
GO

-- Preguntas de seguridad
INSERT INTO PSeguridad VALUES
    ('¿Cómo se llamaba tu primer mascota?',1),
    ('¿En qué ciudad nació?',1),
    ('¿Cuál era el modelo de tu primer coche?',1),
    ('¿Cual es tu color favorito?',0),
    ('¿De dónde es tu padre?',0),
    ('¿Nombre de tu ciudad favorita?',0),
    ('¿Cómo se llamaba tu primer escuela?',0)
    ;
GO

INSERT INTO Roles (Nombre) VALUES ('Usuario'),('Administrador');
GO

-- Configuraciones del sistema
INSERT INTO Configuraciones (Accion, Valor)
SELECT v.Accion, v.Valor
FROM (VALUES
    (N'MinCaracteres',     N'8'),   -- mínimo de caracteres de la contraseña
    (N'CantidadPreguntas', N'3'),   -- preguntas de seguridad a responder (0 = todas las activas)
    (N'MayusMinus',        N'1'),   -- obliga mayúsculas y minúsculas
    (N'NumerosLetras',     N'1'),   -- obliga números y letras
    (N'CaracterEspecial',  N'1'),   -- obliga al menos un carácter especial
    (N'Auth2FA',           N'0'),   -- autenticación en dos pasos por correo
    (N'NoRepetirPass',     N'1'),   -- no repetir contraseñas anteriores
    (N'NoDatosPersonales', N'1')    -- no contener datos personales
) 
AS v(Accion, Valor)
WHERE NOT EXISTS (SELECT 1 FROM Configuraciones WHERE Configuraciones.Accion = v.Accion);
GO

-- Usuario Administrador Inicial (Necesario para el primer uso del sistema
DECLARE @user   VARCHAR(50)  = 'admin';
DECLARE @pass   VARCHAR(50)  = 'admin';              -- temporal
DECLARE @correo NVARCHAR(50) = N'tu_correo@gmail.com'; -- necesario para recuperar la contraseña

IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = @user)
BEGIN
    -- Mismo hash que genera la app: SHA256(contraseña + usuario), en minúsculas
    DECLARE @hash NVARCHAR(64) = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @pass + @user), 2));

    BEGIN TRY
        BEGIN TRANSACTION

            INSERT INTO Personas (Nombre, Apellido, Correo)
            VALUES (N'Administrador', N'Sistema', @correo);
            DECLARE @ID_Persona INT = SCOPE_IDENTITY();

            INSERT INTO Contrasenas (contrasena, fecha_creacion)
            VALUES (@hash, GETDATE());
            DECLARE @ID_Pass INT = SCOPE_IDENTITY();

            INSERT INTO Usuarios (Nombre, ID_Persona, ID_Clave)
            VALUES (@user, @ID_Persona, @ID_Pass);
            DECLARE @ID_Usuario INT = SCOPE_IDENTITY();

            INSERT INTO Historico_Contrasenas (ID_Usuario, ID_Pass, Activo)
            VALUES (@ID_Usuario, @ID_Pass, 1);

            INSERT INTO RolesUsuarios_Comp (ID_Rol, ID_Usuario)
            SELECT ID_Rol, @ID_Usuario FROM Roles WHERE Nombre IN (N'Usuario', N'Administrador');

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO