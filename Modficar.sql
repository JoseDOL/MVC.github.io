USE [crud1]
GO
create PROCEDURE [dbo].[ModificarUser] 
    @dpi bigint,
    @Nombre varchar(100),
    @Apellido varchar(100),
    @FechNac smalldatetime,
    @edad int,
    @profesion varchar(100),
    @nacionalidad varchar(100),
    @telefono varchar(100) 
AS
declare @existe int,
		@resultado int = 0
select @resultado =COUNT(dpi) from Usuario where dpi= @dpi;

if @resultado > 0 
begin
	update Usuario 
	set
    Nombre = @Nombre,
    Apellido = @Apellido,
    FechNac = @FechNac,
    edad =@edad,
    profesion = @profesion,
    nacionalidad = @nacionalidad,
    telefono = @telefono
	from   Usuario where dpi=@dpi;
select  @existe = 1; 
end
else
begin
select  @existe = 0;	
end
select @existe;
RETURN 0 