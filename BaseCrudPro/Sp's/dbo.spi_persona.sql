IF OBJECT_ID('dbo.spc_obtener_nav_menu', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spc_obtener_nav_menu;
END
GO

CREATE PROCEDURE dbo.spi_persona
		@dpi VARCHAR(20), 
		@Nombre VARCHAR (50),
		@Apellido VARCHAR (50),
		@Profesion VARCHAR (50),
		@FechaNacimiento SMALLDATETIME,
		@Edad INT,
		@Telefono VARCHAR (50)
AS
BEGIN
	BEGIN TRY
		
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH;

END
RETURN 0 
GO