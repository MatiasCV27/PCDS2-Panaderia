--create database DBPanaderia;
--go
--use DBPanaderia;
--go
-- Panes
create table Panes (
	idPanes 		Int Identity(1,1) Not null,
    idMarca			int not null,
    nombreP 		Varchar(25) not null,
    descripcionP 	Varchar(200) null,
    costoP			decimal not null,
    fechaCreacionP 	Date,
    fechaVencimiP 	Date,
	stockP			Int not null,
	imagenP			Varchar(Max),
    constraint pk_Panes Primary key(idPanes),
    constraint fk_MarcaP FOREIGN KEY(idMarca) REFERENCES Marca(idMarca),
);
Select * from Panes
-- Procedimientos Panes almacenados
Create Procedure sp_ListarPanes
As
Begin
    Select * From Panes 
End

Create Procedure sp_ObtenerPanes(
    @idPanes    int
)
AS
Begin
    Select * From Panes Where idPanes = @idPanes
End

Create Procedure sp_GuardarPanes(
    @idMarca            int,
    @nombreP             Varchar(25),
    @descripcionP         Varchar(200),
    @costoP                decimal,
    @fechaCreacionP     Date,
    @fechaVencimiP         Date,
	@stockP			Int,
	@imagenP			Varchar(Max)
)
As
Begin
    Insert Into Panes(idMarca,nombreP,descripcionP,costoP,fechaCreacionP,fechaVencimiP,stockP,imagenP) 
    Values(@idMarca,@nombreP,@descripcionP,@costoP,@fechaCreacionP,@fechaVencimiP,@stockP,@imagenP)
End

Create Procedure sp_EditarPanes(
    @idPanes         int,
    @idMarca            int,
    @nombreP             Varchar(25),
    @descripcionP         Varchar(200),
    @costoP                decimal,
    @fechaCreacionP     Date,
    @fechaVencimiP         Date,
	@stockP			Int,
	@imagenP			Varchar(Max)
)
As
Begin
	Update Panes Set idMarca = @idMarca, nombreP = @nombreP, descripcionP = @descripcionP,
    costoP = @costoP, fechaCreacionP = @fechaCreacionP, fechaVencimiP = @fechaVencimiP, stockP = @stockP, 
	imagenP = @imagenP Where idPanes = @idPanes
End

Create Procedure sp_EliminarPanes(
    @idPanes    int
)
AS
Begin
    Delete From Panes Where idPanes = @idPanes
End
-- Bocaditos
create table Bocaditos (
	idBocaditos 	Int Identity(1,1) Not null,
    idMarca			int not null,
    nombreB 		Varchar(25) not null,
    descripcionB 	Varchar(100) null,
    costoB			decimal not null,
    fechaCreacionB 	Date,
    fechaVencimiB 	Date,
    constraint pk_Bocad Primary key(idBocaditos),
    constraint fk_MarcaB FOREIGN KEY(idMarca) REFERENCES Marca(idMarca),
);
-- Pasteles
create table Tortas (
	idTortas		Int Identity(1,1) Not null,
    idMarca			int not null,
    nombreT			Varchar(25) not null,
    descripcionT 	Varchar(100) null,
    costoT			decimal not null,
    fechaCreacionT 	Date,
    fechaVencimi 	Date,
    constraint pk_Tortas Primary key(idTortas),
    constraint fk_MarcaT FOREIGN KEY(idMarca) REFERENCES Marca(idMarca),
);
-- Marca
create table Marca (
	idMarca			Int Identity(1,1) Not null,
    nombreM			Varchar(25) not null,
    descripcionM 	Varchar(100) null,
    constraint pk_Marca Primary key(idMarca)
);

Insert Into Marca Values ('Artesanal', 'Es la marca con lo que la panaderia vende sus propios productos.');
Insert Into Marca Values ('Bimbo', 'Es una empresa mexicana y una de las compañías de panificación más grandes a nivel mundial.');
Insert Into Marca Values ('Dempster', 'Es una marca canadiense de pan que ofrece una variedad de productos.');
Insert Into Marca Values ('Aryzta', 'Es una empresa de panificación con sede en Suiza que suministra productos a nivel internacional.');
Insert Into Marca Values ('Hovis', 'Marca británica de pan que se especializa en panes de trigo integral y productos relacionados.');

-- USUARIOS

Create Table usuarios (
	id		int identity(1000,1),
	usuario varchar(50),
	contra	varbinary(500)
)
Create Procedure sp_agregausuario
	@usuario	varchar(50),
	@contra		varchar(50),
	@patron		varchar(50)
as
begin
insert into usuarios(usuario,contra)values(@usuario,ENCRYPTBYPASSPHRASE(@patron,@contra))
end

create procedure sp_validarusuario
	@usuario	varchar(50),
	@contra		varchar(50),
	@patron		varchar(50)
as
begin
select*from usuarios where usuario=@usuario and CONVERT(VARCHAR(50),DECRYPTBYPASSPHRASE(@patron, contra))=@contra
end

select * from usuarios;
select * from sys.procedures;

sp_agregausuario 'admin','admin','panaderia'
sp_agregausuario 'user','user','panaderia'

-- Procedimientos Bocaditos almacenados
Create Procedure sp_ListarBocaditos
As
Begin
    Select * From Bocaditos 
End

Create Procedure sp_ObtenerBocaditos(
    @idBocaditos    int
)
AS
Begin
    Select * From Bocaditos Where idBocaditos = @idBocaditos
End

Create Procedure sp_GuardarBocaditos(
    @idMarca            int,
    @nombreB             Varchar(25),
    @descripcionB         Varchar(100),
    @costoB                decimal,
    @fechaCreacionB     Date,
    @fechaVencimiB         Date
)
As
Begin
    Insert Into Bocaditos(idMarca,nombreB,descripcionB,costoB,fechaCreacionB,fechaVencimiB) 
    Values(@idMarca,@nombreB,@descripcionB,@costoB,@fechaCreacionB,@fechaVencimiB)
End

Create Procedure sp_EditarBocaditos(
    @idBocaditos         int,
    @idMarca            int,
    @nombreB             Varchar(25),
    @descripcionB         Varchar(100),
    @costoB                decimal,
    @fechaCreacionB     Date,
    @fechaVencimiB         Date
)
As
Begin
    Update Bocaditos Set idMarca = @idMarca, nombreB = @nombreB, descripcionB = @descripcionB,
    costoB = @costoB, fechaCreacionB = @fechaCreacionB, fechaVencimiB = @fechaVencimiB
    Where idBocaditos = @idBocaditos
End

Create Procedure sp_EliminarBocaditos(
    @idBocaditos    int
)
AS
Begin
    Delete From Bocaditos Where idBocaditos = @idBocaditos
End
-- Procedimientos Tortas almacenados
Create Procedure sp_ListarTortas
As
Begin
    Select * From Tortas 
End

Create Procedure sp_ObtenerTortas(
    @idTortas    int
)
AS
Begin
    Select * From Tortas Where idTortas = @idTortas
End

Create Procedure sp_GuardarTortas(
    @idMarca            int,
    @nombreT             Varchar(25),
    @descripcionT         Varchar(100),
    @costoT                decimal,
    @fechaCreacionT     Date,
    @fechaVencimi         Date
)
As
Begin
    Insert Into Tortas(idMarca,nombreT,descripcionT,costoT,fechaCreacionT,fechaVencimi) 
    Values(@idMarca,@nombreT,@descripcionT,@costoT,@fechaCreacionT,@fechaVencimi)
End

Create Procedure sp_EditarTortas(
    @idTortas         int,
    @idMarca            int,
    @nombreT             Varchar(25),
    @descripcionT         Varchar(100),
    @costoT                decimal,
    @fechaCreacionT     Date,
    @fechaVencimi         Date
)
As
Begin
    Update Tortas Set idMarca = @idMarca, nombreT = @nombreT, descripcionT = @descripcionT,
    costoT = @costoT, fechaCreacionT = @fechaCreacionT, fechaVencimi = @fechaVencimi
    Where idTortas = @idTortas
End

Create Procedure sp_EliminarTortas(
    @idTortas    int
)
AS
Begin
    Delete From Tortas Where idTortas = @idTortas
End
-- Procedimientos Marca almacenados
Create Procedure sp_ListarMarcas
As
Begin
    Select * From Marca 
End