IF OBJECT_ID('dbo.spc_obtener_nav_menu', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spc_obtener_nav_menu;
END
GO

CREATE PROCEDURE dbo.spc_obtener_nav_menu
AS
BEGIN
	SELECT id_nav AS 'id',
		txt_nombre AS 'name',
		controller AS 'controller',
		accion AS 'action',
		icono AS 'icon'
	FROM menu_nav_bar
END
RETURN 0 
GO