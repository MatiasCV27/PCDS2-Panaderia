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
	stockB			Int not null,
	imagenB			Varchar(Max),
    constraint pk_Bocad Primary key(idBocaditos),
    constraint fk_MarcaB FOREIGN KEY(idMarca) REFERENCES Marca(idMarca),
);
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
    @fechaVencimiB         Date,
	@stockB			Int,
	@imagenB			Varchar(Max)
)
As
Begin
    Insert Into Bocaditos(idMarca,nombreB,descripcionB,costoB,fechaCreacionB,fechaVencimiB,stockB,imagenB) 
    Values(@idMarca,@nombreB,@descripcionB,@costoB,@fechaCreacionB,@fechaVencimiB,@stockB,@imagenB)
End

Create Procedure sp_EditarBocaditos(
    @idBocaditos         int,
    @idMarca            int,
    @nombreB             Varchar(25),
    @descripcionB         Varchar(100),
    @costoB                decimal,
    @fechaCreacionB     Date,
    @fechaVencimiB         Date,
	@stockB			Int,
	@imagenB			Varchar(Max)
)
As
Begin
    Update Bocaditos Set idMarca = @idMarca, nombreB = @nombreB, descripcionB = @descripcionB,
    costoB = @costoB, fechaCreacionB = @fechaCreacionB, fechaVencimiB = @fechaVencimiB, stockB = @stockB, imagenB = @imagenB
    Where idBocaditos = @idBocaditos
End

Create Procedure sp_EliminarBocaditos(
    @idBocaditos    int
)
AS
Begin
    Delete From Bocaditos Where idBocaditos = @idBocaditos
End
-- Pasteles
create table Tortas (
	idTortas		Int Identity(1,1) Not null,
    idMarca			int not null,
    nombreT			Varchar(25) not null,
    descripcionT 	Varchar(100) null,
    costoT			decimal not null,
    fechaCreacionT 	Date,
    fechaVencimi 	Date,
	stockT			Int not null,
	imagenT			Varchar(Max),
    constraint pk_Tortas Primary key(idTortas),
    constraint fk_MarcaT FOREIGN KEY(idMarca) REFERENCES Marca(idMarca),
);
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
    @fechaVencimi         Date,
	@stockT			Int,
	@imagenT			Varchar(Max)
)
As
Begin
    Insert Into Tortas(idMarca,nombreT,descripcionT,costoT,fechaCreacionT,fechaVencimi,stockT,imagenT) 
    Values(@idMarca,@nombreT,@descripcionT,@costoT,@fechaCreacionT,@fechaVencimi,@stockT,@imagenT)
End

Create Procedure sp_EditarTortas(
    @idTortas         int,
    @idMarca            int,
    @nombreT             Varchar(25),
    @descripcionT         Varchar(100),
    @costoT                decimal,
    @fechaCreacionT     Date,
    @fechaVencimi         Date,
	@stockT			Int,
	@imagenT			Varchar(Max)
)
As
Begin
    Update Tortas Set idMarca = @idMarca, nombreT = @nombreT, descripcionT = @descripcionT,
    costoT = @costoT, fechaCreacionT = @fechaCreacionT, fechaVencimi = @fechaVencimi, stockT = @stockT, imagenT = @imagenT
    Where idTortas = @idTortas
End

Create Procedure sp_EliminarTortas(
    @idTortas    int
)
AS
Begin
    Delete From Tortas Where idTortas = @idTortas
End
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
create table Usuarios (
	idUsuario	Int Identity(1,1) Not null,
	usuario		Varchar(50) Not null,
	correo		Varchar(50) Not null,
	clave		Varchar(50) Not null,
	rol		Varchar(30) Not null,
    constraint pk_Usuarios Primary key(idUsuario),
);

Insert Into Usuarios Values('admin', 'admin@gmail.com', '123', 'ADMIN');
Insert Into Usuarios Values('user', 'user@gmail.com', '123', 'USER');

Create Procedure sp_ListarUsuarios
As
Begin
    Select * From Usuarios 
End

Create Procedure sp_ObtenerUsuarios(
    @idUsuario    int
)
AS
Begin
    Select * From Usuarios Where idUsuario = @idUsuario
End

Create Procedure sp_GuardarUsuarios(
	@usuario		Varchar(50),
	@correo		Varchar(50),
	@clave		Varchar(50),
	@rol		Varchar(30)
)
As
Begin
    Insert Into Usuarios(usuario,correo,clave,rol) 
    Values(@usuario,@correo,@clave,@rol)
End

Create Procedure sp_EditarUsuarios(
    @idUsuario   int,
    @usuario	Varchar(50),
	@correo		Varchar(50),
	@clave		Varchar(50),
	@rol		Varchar(30)
)
As
Begin
    Update Usuarios Set usuario = @usuario, correo = @correo, clave = @clave, rol = @rol
    Where idUsuario = @idUsuario
End

Create Procedure sp_EliminarUsuarios(
    @idUsuario    int
)
AS
Begin
    Delete From Usuarios Where idUsuario = @idUsuario
End