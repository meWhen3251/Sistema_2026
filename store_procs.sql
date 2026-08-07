--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- STORED PROCEDURES
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

/*
  ____       _           _           _____            __              _        __                                 _   __        
 / ___|  ___| | ___  ___| |_ ___ _  | ____|_ ____   _/_/ __ _ _ __   (_)_ __  / _| ___  _ __ _ __ ___   __ _  ___(_) /_/  _ __  
 \___ \ / _ \ |/ _ \/ __| __/ __(_) |  _| | '_ \ \ / / |/ _` | '_ \  | | '_ \| |_ / _ \| '__| '_ ` _ \ / _` |/ __| |/ _ \| '_ \ 
  ___) |  __/ |  __/ (__| |_\__ \_  | |___| | | \ V /| | (_| | | | | | | | | |  _| (_) | |  | | | | | | (_| | (__| | (_) | | | |
 |____/ \___|_|\___|\___|\__|___(_) |_____|_| |_|\_/ |_|\__,_|_| |_| |_|_| |_|_|  \___/|_|  |_| |_| |_|\__,_|\___|_|\___/|_| |_|
   __ _| |  ___(_)___| |_ ___ _ __ ___   __ _   ___  ___  __ _ _/_/_ _ __    _ __   ___  ___ ___  ___(_) __| | __ _  __| |      
  / _` | | / __| / __| __/ _ \ '_ ` _ \ / _` | / __|/ _ \/ _` | | | | '_ \  | '_ \ / _ \/ __/ _ \/ __| |/ _` |/ _` |/ _` |      
 | (_| | | \__ \ \__ \ ||  __/ | | | | | (_| | \__ \  __/ (_| | |_| | | | | | | | |  __/ (_|  __/\__ \ | (_| | (_| | (_| |      
  \__,_|_| |___/_|___/\__\___|_| |_| |_|\__,_| |___/\___|\__, |\__,_|_| |_| |_| |_|\___|\___\___||___/_|\__,_|\__,_|\__,_|      
                                                         |___/                                                                  
*/
USE Sistema_2026;
GO
-- 1. Login de usuario
CREATE PROCEDURE SP_LoginUsuario
    @Nombre NVARCHAR(100),
    @contrasena NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION

	SET NOCOUNT ON;

	SELECT Usuarios.ID_Usuario, Usuarios.Nombre,Contrasenas.contrasena,Historico_Contrasenas.Activo,Contrasenas.fecha_creacion
	FROM Usuarios
	INNER JOIN Historico_Contrasenas ON Usuarios.ID_Usuario = Historico_Contrasenas.ID_Usuario
	INNER JOIN Contrasenas ON Historico_Contrasenas.ID_Pass = Contrasenas.ID_Pass
	WHERE Usuarios.Nombre = @Nombre
		AND Contrasenas.contrasena = @contrasena
		AND Historico_Contrasenas.Activo = 1
	COMMIT TRANSACTION
END
GO

-- 2. Obtener preguntas de seguridad
CREATE PROCEDURE SP_ObtenerPreguntasSeguridad
    @ID_Usuario INT
AS
BEGIN
	BEGIN TRANSACTION

	SELECT PSeguridad.ID_Pregunta,PSeguridad.Pregunta
	FROM PSeguridad
	INNER JOIN RSeguridad ON PSeguridad.ID_Pregunta = RSeguridad.ID_Pregunta
	INNER JOIN RSeguridadUsuarios_Comp ON RSeguridad.ID_Respuesta = RSeguridadUsuarios_Comp.ID_Respuesta
	WHERE RSeguridadUsuarios_Comp.ID_Usuario = @ID_Usuario
    AND PSeguridad.Habilitada = 1

	COMMIT TRANSACTION
END
GO

-- 3. Verificar respuestas de seguridad
CREATE PROCEDURE SP_VerificarRespuestasSeguridad
    @ID_Usuario INT,
    @Respuesta NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION

	SET NOCOUNT ON;

	SELECT RSeguridad.respuesta
	FROM RSeguridad
	INNER JOIN RSeguridadUsuarios_Comp ON RSeguridad.ID_Respuesta = RSeguridadUsuarios_Comp.ID_Respuesta
	WHERE RSeguridadUsuarios_Comp.ID_Usuario = @ID_Usuario
		AND RSeguridad.respuesta = @Respuesta

	IF @@ROWCOUNT > 0
		RETURN 0
	ELSE
		RETURN 1

	COMMIT TRANSACTION
END
GO

-- 4. Envío de código de recuperación
CREATE PROCEDURE SP_VerificarMail
    @Correo NVARCHAR(150)
AS
BEGIN
	BEGIN TRANSACTION
    DECLARE @flag_existe INT
	IF EXISTS (SELECT 1 FROM Usuarios
			   INNER JOIN Personas ON Usuarios.ID_Persona = Personas.ID_Persona
			   WHERE Personas.Correo = @Correo)
	 BEGIN
		 SET @flag_existe = 1
	 END
    ELSE
     BEGIN
		 SET @flag_existe = 0
	 END
	COMMIT TRANSACTION

    RETURN @flag_existe
END
GO

-- 5. Cargar roles para la listbox
CREATE PROCEDURE SP_CargaRoles
AS
BEGIN
    SELECT Nombre,Descripcion FROM Roles
END
GO

-- 6. Cargar preguntas de seguridad para el dropdown, donde se pueden ver y ajustar luego
CREATE PROCEDURE SP_CargaPreguntasSeguridad
AS
BEGIN
    SELECT Pregunta, Habilitada, ID_Pregunta FROM PSeguridad
END
GO

-- 7. Obtener el número total de logins para un usuario para comprender si es su primer inicio o no
CREATE PROCEDURE SP_LoginsTotal
@usuario VARCHAR(20),
@pass VARCHAR(50)
AS
BEGIN
    DECLARE @id_user VARCHAR(20);
    IF EXISTS (SELECT * FROM Usuarios WHERE nombre=@usuario)
    BEGIN
        SET @id_user = (SELECT Id_Usuario FROM Usuarios WHERE nombre=@usuario)
        SELECT COUNT(*) 
        FROM Historico_contrasenas
        INNER JOIN Contrasenas ON Historico_contrasenas.id_pass = Contrasenas.id_pass
        WHERE historico_contrasenas.Id_usuario = @id_user;
    END
END
GO

-- 8. Otro método para tener logins totales, sin chequeo de si existe incluso
CREATE PROCEDURE SP_ObtenerCantidadContrasenas
@ID_Usuario INT
AS
BEGIN
    BEGIN TRANSACTION
        SELECT COUNT(*) AS CantidadContrasenas FROM Historico_Contrasenas
        WHERE ID_Usuario = @ID_Usuario;
    COMMIT TRANSACTION
END
GO

-- 9. CHEQUEO DE ROL, ESPECÍFICAMENTE SI ES ADMINISTRADOR

CREATE PROCEDURE SP_EsAdministrador
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRANSACTION
        SET NOCOUNT ON;

        SELECT *
        FROM RolesUsuarios_Comp
        INNER JOIN Roles ON RolesUsuarios_Comp.ID_Rol = Roles.ID_Rol
        WHERE RolesUsuarios_Comp.ID_Usuario = @ID_Usuario
        AND Roles.Nombre = 'Administrador';
    COMMIT TRANSACTION
END
GO


-- 10. SP PARA CARGAR TODAS LAS CONFIGURACIONES

CREATE PROCEDURE SP_CargarConfiguraciones
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Accion, Valor FROM Configuraciones;
END
GO

-- 11. Cargar Usuarios para la listbox, con su ID para luego poder hacer modificaciones
CREATE PROCEDURE SP_CargaUsuarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Usuarios
END
GO

-- 11. Obtener usuario por correo
CREATE PROCEDURE SP_ObtenerUsuarioPorCorreo
    @Correo NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Usuarios.ID_Usuario, Usuarios.Nombre, Personas.Correo
    FROM Usuarios
    INNER JOIN Personas ON Usuarios.ID_Persona = Personas.ID_Persona
    WHERE Personas.Correo = @Correo
END
GO

-- 12. Obtener correo por usuario
CREATE PROCEDURE SP_ObtenerCorreoPorUsuario
	@user NVARCHAR(50)
AS
BEGIN
	SELECT Usuarios.Nombre, Personas.Correo
	FROM Personas 
	INNER JOIN Usuarios ON Personas.ID_Persona = Usuarios.ID_Persona
	WHERE Usuarios.Nombre=@user
END
GO
/*
  ___                     _                 _   _           _       _                 ____                              _        __                    
 |_ _|_ __  ___  ___ _ __| |_ ___   _   _  | | | |_ __   __| | __ _| |_ ___  ___ _   / ___|__ _ _ __ __ _  __ _ _ __   (_)_ __  / _| ___     ___ _ __  
  | || '_ \/ __|/ _ \ '__| __/ __| | | | | | | | | '_ \ / _` |/ _` | __/ _ \/ __(_) | |   / _` | '__/ _` |/ _` | '_ \  | | '_ \| |_ / _ \   / _ \ '_ \ 
  | || | | \__ \  __/ |  | |_\__ \ | |_| | | |_| | |_) | (_| | (_| | ||  __/\__ \_  | |__| (_| | | | (_| | (_| | | | | | | | | |  _| (_) | |  __/ | | |
 |___|_| |_|___/\___|_|   \__|___/  \__, |  \___/| .__/ \__,_|\__,_|\__\___||___(_)  \____\__,_|_|  \__, |\__,_|_| |_| |_|_| |_|_|  \___/   \___|_| |_|
  _         _                       |___/        |_|_       _                                       |___/                                              
 | | __ _  | |__   __ _ ___  ___    __| | ___    __| | __ _| |_ ___  ___                                                                               
 | |/ _` | | '_ \ / _` / __|/ _ \  / _` |/ _ \  / _` |/ _` | __/ _ \/ __|                                                                              
 | | (_| | | |_) | (_| \__ \  __/ | (_| |  __/ | (_| | (_| | || (_) \__ \                                                                              
 |_|\__,_| |_.__/ \__,_|___/\___|  \__,_|\___|  \__,_|\__,_|\__\___/|___/                                                                              
*/

-- 11. Crear preguntas de seguridad para el sistema
CREATE PROCEDURE SP_AgregarPreguntaSeguridad
    @Pregunta NVARCHAR(50)
    AS
    BEGIN
        BEGIN TRANSACTION
            INSERT INTO PSeguridad VALUES (@Pregunta, 0);
        COMMIT TRANSACTION
    END
GO

-- 12. crear familias
CREATE PROCEDURE SP_InsertarFamilia
    @NombreFamilia NVARCHAR(100)
AS
BEGIN
	BEGIN TRANSACTION

	INSERT INTO Familia (Nombre)
	VALUES (@NombreFamilia)

	SELECT SCOPE_IDENTITY() AS ID_Familia

	COMMIT TRANSACTION
END
GO

-- 13. crear roles
CREATE PROCEDURE SP_InsertarRol
    @NombreRol NVARCHAR(100),
	@Descripcion NVARCHAR(100)
AS
BEGIN
	BEGIN TRANSACTION

	INSERT INTO Roles (Nombre,Descripcion)
	VALUES (@NombreRol,@Descripcion)
	COMMIT TRANSACTION

    SELECT Nombre, Descripcion FROM Roles
END
GO

-- 14. crear configuraciones
CREATE PROCEDURE SP_InsertarConfiguracion
    @Accion NVARCHAR(25),
    @Valor  NVARCHAR(30)
AS
BEGIN
    BEGIN TRANSACTION
        INSERT INTO Configuraciones (Accion, Valor)
        VALUES (@Accion, @Valor);
    COMMIT TRANSACTION
END
GO

-- 15. crear permisos
CREATE PROCEDURE SP_InsertarPermiso
    @Permiso NVARCHAR(25),
    @Descripcion NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION
        INSERT INTO Permisos (Permiso, Descripcion)
        VALUES (@Permiso, @Descripcion);
    COMMIT TRANSACTION
END
GO

-- 16. Crear usuarios completos
CREATE PROCEDURE SP_InsertarUsuarioCompleto
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Correo NVARCHAR(150),
    @NombreUsuario NVARCHAR(100),
    @contrasena NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT * FROM Personas WHERE Correo = @Correo)
    BEGIN
        RAISERROR('El correo ya está registrado en el sistema.', 16, 1)
        RETURN
    END
    ELSE
    BEGIN

    -- Primero cargar tablas fuertes, como la de personas y contraseñas
-- personas
        BEGIN TRANSACTION
	        INSERT INTO Personas (Nombre, Apellido, Correo)
	        VALUES (@Nombre,@Apellido,@Correo)
            DECLARE @ID_Persona INT = SCOPE_IDENTITY()
        COMMIT TRANSACTION

-- contraseñas
        BEGIN TRANSACTION
            INSERT INTO Contrasenas (contrasena,fecha_creacion)
            VALUES (@contrasena, GETDATE());
            DECLARE @ID_Pass INT = SCOPE_IDENTITY()
        COMMIT TRANSACTION

--Usuarios, con el pass actual
        BEGIN TRANSACTION
	        INSERT INTO Usuarios (Nombre,ID_Persona,ID_Clave)
	        VALUES (@NombreUsuario,@ID_Persona,@ID_Pass)
	        DECLARE @ID_Usuario INT = SCOPE_IDENTITY()
        COMMIT TRANSACTION

--Histórico de contraseñas
        BEGIN TRANSACTION
            INSERT INTO Historico_Contrasenas (ID_Usuario,ID_Pass,Activo)
            VALUES (@ID_Usuario,@ID_Pass,1)
	    COMMIT TRANSACTION

--Rol inicial
        BEGIN TRANSACTION
            INSERT INTO RolesUsuarios_Comp (ID_Rol,ID_Usuario) VALUES (1, @ID_Usuario)
        COMMIT TRANSACTION

    END
END
GO

-- 17. Agregar nueva contraseña, 
CREATE PROCEDURE SP_InsertarContrasena
    @contrasena NVARCHAR(255),
    @ID_Usuario INT
AS
BEGIN
	BEGIN TRANSACTION

        IF NOT EXISTS (SELECT * FROM Contrasenas 
            inner join Historico_Contrasenas on Contrasenas.ID_Pass = Historico_Contrasenas.ID_Pass
            WHERE Historico_Contrasenas.ID_Usuario = @ID_Usuario AND Contrasenas.contrasena = @contrasena)
            BEGIN

                BEGIN TRANSACTION
                    INSERT INTO Contrasenas (contrasena,fecha_creacion)
	                VALUES (@contrasena, GETDATE());
                    DECLARE @ID_Pass INT = SCOPE_IDENTITY()
                COMMIT TRANSACTION
        
                BEGIN TRANSACTION
                    UPDATE Historico_Contrasenas
                    SET Activo = 0
                    WHERE ID_Usuario = @ID_Usuario
                COMMIT TRANSACTION
            
                BEGIN TRANSACTION
                    INSERT INTO Historico_Contrasenas (ID_Usuario,ID_Pass,Activo)
                    VALUES (@ID_Usuario,@ID_Pass,1)
                COMMIT TRANSACTION
            END
        ELSE
        BEGIN
            RAISERROR('La contraseña no puede ser igual a las anteriores.', 16, 1)
            RETURN
        END
    COMMIT TRANSACTION
END
GO

-- 18. Crear respuestas de seguridad para un usuario, asociándolas a sus preguntas correspondientes
CREATE PROCEDURE SP_InsertarRespuestaSeguridad
    @ID_Pregunta INT,
    @Respuesta NVARCHAR(255),
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRANSACTION

    SET NOCOUNT ON;

    INSERT INTO RSeguridad (ID_Pregunta, Respuesta)
    VALUES (@ID_Pregunta, @Respuesta);
    DECLARE @ID_Respuesta INT = SCOPE_IDENTITY()

    INSERT INTO RSeguridadUsuarios_Comp (ID_Respuesta, ID_Usuario)
    VALUES (@ID_Respuesta, @ID_Usuario)

    COMMIT TRANSACTION
END
GO

-- 19. Modificar configuración
CREATE PROCEDURE SP_GuardarConfiguracion
    @Accion NVARCHAR(25),
    @Valor  NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Configuraciones WHERE Accion = @Accion)
BEGIN
BEGIN TRANSACTION 
        UPDATE Configuraciones
        SET Valor = @Valor
        WHERE Accion = @Accion;
COMMIT TRANSACTION
END
    ELSE
BEGIN
BEGIN TRANSACTION
        INSERT INTO Configuraciones (Accion, Valor)
        VALUES (@Accion, @Valor);
COMMIT TRANSACTION
END
END
GO


-- 20. Asociar familias con roles
CREATE PROCEDURE SP_InsertarFamiliaRol
    @ID_Familia INT,
    @ID_Rol INT
AS
BEGIN
	BEGIN TRANSACTION

	SET NOCOUNT ON;

	INSERT INTO Familia_Comp (ID_Familia,ID_Rol)
	VALUES (@ID_Familia,@ID_Rol)

	COMMIT TRANSACTION
END
GO

-- 21. Asociar roles con usuarios
CREATE PROCEDURE SP_AgregarRolUsuario
    @Rol VARCHAR(50),
    @User VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Roles
    INNER JOIN RolesUsuarios_Comp ON Roles.ID_Rol = RolesUsuarios_Comp.ID_Rol
    INNER JOIN Usuarios ON RolesUsuarios_Comp.ID_Usuario = Usuarios.ID_Usuario
    WHERE Roles.Nombre = @Rol AND Usuarios.Nombre=@User)
        BEGIN
            BEGIN TRANSACTION

            DECLARE @ID_Rol INT = (SELECT ID_Rol FROM Roles WHERE Nombre = @Rol)
            DECLARE @ID_Usuario INT = (SELECT ID_Usuario FROM Usuarios WHERE Nombre=@User)
                INSERT INTO RolesUsuarios_Comp (ID_Rol, ID_Usuario)
                VALUES (@ID_Rol, @ID_Usuario)
            COMMIT TRANSACTION
        END
    ELSE
    BEGIN
            RAISERROR('El usuario ya tiene asignado el rol.', 16, 1)
            RETURN
        END
END
GO

-- 22. Modificar nombre de familia
CREATE PROCEDURE SP_ModificarFamilia
    @ID_Familia INT,
    @NuevoNombre NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT * FROM Familia WHERE ID_Familia = @ID_Familia)
        BEGIN
        BEGIN TRANSACTION
            UPDATE Familia
            SET Nombre = @NuevoNombre
            WHERE ID_Familia = @ID_Familia
        COMMIT TRANSACTION
        END
    ELSE
    BEGIN
        RAISERROR('La familia con ID %d no existe.', 16, 1, @ID_Familia)
        RETURN
    END
END
GO

-- 23. Modificar nombre de rol
CREATE PROCEDURE SP_ModificarRol
    @ID_Rol INT,
    @NuevoNombre NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT * FROM Roles WHERE ID_Rol = @ID_Rol)
        BEGIN
        BEGIN TRANSACTION
            UPDATE Roles
            SET Nombre = @NuevoNombre
            WHERE ID_Rol = @ID_Rol
        COMMIT TRANSACTION
        END
END
GO



-- 24. Actualizar estado de pregunta de seguridad, para habilitar o deshabilitar su uso en el sistema
CREATE PROCEDURE SP_ActualizarEstadoPregunta
  @pregunta nvarchar(50)
AS
BEGIN
IF EXISTS(SELECT Habilitada FROM PSeguridad WHERE Pregunta=@pregunta)
  BEGIN
    IF((SELECT Habilitada FROM PSeguridad WHERE Pregunta=@pregunta)=0)
      BEGIN
        BEGIN TRANSACTION
          UPDATE PSeguridad SET Habilitada=1 WHERE Pregunta=@pregunta
        COMMIT TRANSACTION
      END
    ELSE
      BEGIN
        BEGIN TRANSACTION
          UPDATE PSeguridad SET Habilitada=0 WHERE Pregunta=@pregunta
        COMMIT TRANSACTION
      END
  END
END
GO


-- 25. Modificar pregunta de seguridad, para corregir errores o actualizar su redacción
CREATE PROCEDURE SP_ModificarPreguntaSeguridad
@nuevaPregunta nvarchar(50),
@preguntaActual nvarchar(50)
AS
BEGIN
BEGIN TRANSACTION
        UPDATE PSeguridad
        SET Pregunta = @nuevaPregunta
        WHERE Pregunta = @preguntaActual;
    COMMIT TRANSACTION
END
GO

-- 26. Asociar permisos con roles
CREATE PROCEDURE SP_AgregarPermisoRol
    @ID_Permiso INT,
    @ID_Rol INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM PermisosRoles_Comp WHERE ID_Permiso = @ID_Permiso AND ID_Rol = @ID_Rol)
    BEGIN
        BEGIN TRANSACTION
        INSERT INTO PermisosRoles_Comp (ID_Permiso, ID_Rol)
        VALUES (@ID_Permiso,@ID_Rol)
        COMMIT TRANSACTION
    END
END
GO

-- 27. Asociar permisos con usuarios
CREATE PROCEDURE SP_AgregarPermisoUsuario
    @ID_Permiso INT,
    @ID_Usuario INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM PermisosUsuarios_Comp WHERE ID_Permiso = @ID_Permiso AND ID_Usuario = @ID_Usuario)
    BEGIN
        BEGIN TRANSACTION
        INSERT INTO PermisosUsuarios_Comp (ID_Permiso, ID_Usuario)
        VALUES (@ID_Permiso,@ID_Usuario)
        COMMIT TRANSACTION
    END
END
GO

-- 28. Asociar permisos con familias
CREATE PROCEDURE SP_AgregarPermisoFamilia
    @ID_Permiso INT,
    @ID_Familia INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM FamiliaPermisos_Comp WHERE ID_Permiso = @ID_Permiso AND ID_Familia = @ID_Familia)
    BEGIN
        BEGIN TRANSACTION
        INSERT INTO FamiliaPermisos_Comp (ID_Permiso, ID_Familia)
        VALUES (@ID_Permiso,@ID_Familia)
        COMMIT TRANSACTION
    END
END
GO

-- 29. Asociar familias con usuarios
CREATE PROCEDURE SP_AgregarFamiliaUsuario
    @ID_Familia INT,
    @ID_Usuario INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM FamiliaUsuarios_Comp WHERE ID_Familia = @ID_Familia AND ID_Usuario = @ID_Usuario)
    BEGIN
        BEGIN TRANSACTION
        INSERT INTO FamiliaUsuarios_Comp (ID_Familia, ID_Usuario)
        VALUES (@ID_Familia,@ID_Usuario)
        COMMIT TRANSACTION
    END
END
GO

-- 30. Asociar familias con permisos
CREATE PROCEDURE SP_AgregarFamiliaPermiso
    @ID_Familia INT,
    @ID_Permiso INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM FamiliaPermisos_Comp WHERE ID_Familia = @ID_Familia AND ID_Permiso = @ID_Permiso)
    BEGIN
        BEGIN TRANSACTION
        INSERT INTO FamiliaPermisos_Comp (ID_Familia, ID_Permiso)
        VALUES (@ID_Familia,@ID_Permiso)
        COMMIT TRANSACTION
    END
END
GO