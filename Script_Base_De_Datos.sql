------==========CREANDO LA TABLA USUARIO=============--------------------
CREATE TABLE TBL_USUARIOS
(
	IDUSUARIO INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE_APELLIDOS VARCHAR(50),
	LOGIN VARCHAR(50),
	PASSWORD VARCHAR(50),
	ICONO IMAGE,
	NOMBRE_ICON VARCHAR(MAX),
	CORREO VARCHAR(MAX),
	ROL VARCHAR(MAX)
)
------==========PROCEDIMIENTO PARA INSERTAR USUARIO===========------------
CREATE PROCEDURE SP_INSERTAR_USUARIO
@NOMBRE_APELLIDOS VARCHAR(50),
@LOGIN VARCHAR(50),
@PASSWORD VARCHAR(50),
@ICONO IMAGE,
@NOMBRE_ICON VARCHAR(MAX),
@CORREO VARCHAR(MAX),
@ROL VARCHAR(MAX)
AS
IF EXISTS (SELECT LOGIN FROM TBL_USUARIOS WHERE LOGIN=@LOGIN AND NOMBRE_ICON=@NOMBRE_ICON)
	BEGIN
	RAISERROR ('YA EXISTE UN USUARIO CON ESE LOGIN Y CON ESE ICONO',16,1)
	END
ELSE
	BEGIN
	INSERT INTO TBL_USUARIOS VALUES (@NOMBRE_APELLIDOS,@LOGIN,@PASSWORD,@ICONO,@NOMBRE_ICON,@CORREO,@ROL )
	END
GO


---==PROCEDIMIENTO PARA ACTUALIZAR USUARIO========-------------
CREATE PROCEDURE SP_EDITAR_USUARIO
@IDUSUARIO INT,
@NOMBRE_APELLIDOS VARCHAR(50),
@LOGIN VARCHAR(50),
@PASSWORD VARCHAR(50),
@ICONO IMAGE,
@NOMBRE_ICON VARCHAR(MAX),
@CORREO VARCHAR(MAX),
@ROL VARCHAR(MAX)
AS

IF EXISTS(SELECT LOGIN,IDUSUARIO FROM TBL_USUARIOS WHERE (LOGIN=@LOGIN AND IDUSUARIO<>@IDUSUARIO) OR 
														(NOMBRE_APELLIDOS=@NOMBRE_APELLIDOS AND IDUSUARIO<>@IDUSUARIO))
	BEGIN
	RAISERROR ('YA SE ESTA USANDO EL USUARIO CON ESE LOGIN Y CON ESE ICONO',16,1)
	END
ELSE
	BEGIN
	UPDATE TBL_USUARIOS SET NOMBRE_APELLIDOS=@NOMBRE_APELLIDOS,LOGIN=@LOGIN,PASSWORD=@PASSWORD,
							ICONO=@ICONO,NOMBRE_ICON=@NOMBRE_ICON,CORREO=@CORREO,ROL=@ROL
		   FROM TBL_USUARIOS WHERE IDUSUARIO=@IDUSUARIO 
	END

GO


----=========PROCEDIMIENTO PARA BUSCAR USUARIO================-----------------
ALTER PROCEDURE SP_BUSCAR_USUARIO
@BUSQUEDA VARCHAR(50)
AS
SELECT * FROM TBL_USUARIOS
WHERE NOMBRE_APELLIDOS + LOGIN  LIKE '%'+ @BUSQUEDA + '%'
ORDER BY IDUSUARIO DESC
GO


-----==============PROCEDIMIENTO PARA ELIMINAR USUARIO=================-------------
CREATE PROCEDURE SP_ELIMINAR_USUARIO
@IDUSUARIO int,
@LOGIN VARCHAR(50)
AS

IF EXISTS (SELECT LOGIN FROM TBL_USUARIOS WHERE LOGIN='admin')
	BEGIN
	RAISERROR ('NO SE PUEDE ELIMINAR AL ADMINISTARDOR',16,1)
	END
ELSE
	BEGIN
	DELETE FROM TBL_USUARIOS WHERE IDUSUARIO=@IDUSUARIO AND LOGIN <>'admin'		
	END
GO



