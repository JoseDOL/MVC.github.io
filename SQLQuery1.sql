use crud1;
drop table Usuario ;
create table Usuario (
	dpi bigint,
    Nombre varchar(100),
    Apellido varchar(100),
    FechNac smalldatetime,
    edad int,
    profesion varchar(100),
    nacionalidad varchar(100),
    telefono varchar(100),
	sn_activo int
);

delete Usuario
-------------------------------------------------------
exec InsertarUser 1234567890123015, 'jose', 'ordoñez', '25/03/1991', 32, 'programador', 'USA', '20012214' 
-------------------------------------------------------
CREATE PROCEDURE dbo.InsertarUser 
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

if @resultado = 0 
begin
	insert into Usuario (dpi,
    Nombre,
    Apellido,
    FechNac,
    edad,
    profesion,
    nacionalidad,
    telefono,
	sn_activo) 
	values(
	@dpi,
    @Nombre,
    @Apellido,
    @FechNac,
    @edad,
    @profesion,
    @nacionalidad,
    @telefono,
	1);
select  @existe = 1; 
end
else
begin
select  @existe = 0;	
end
select @existe;
RETURN 0 
------------------------
select * from Usuario

 drop  PROCEDURE dbo.InsertarUser