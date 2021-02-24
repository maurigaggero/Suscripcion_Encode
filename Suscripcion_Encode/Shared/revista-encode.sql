create database revista
go

use revista
go

create table Suscripcion
(
IdAsociacion int identity primary key,
IdSuscriptor int not null,
FechaAlta datetime not null,
FechaFin datetime null,
MotivoFin nvarchar null,
)

create table Suscriptor
(
IdSuscriptor int identity primary key,
Nombre nvarchar not null,
Apellido nvarchar not null,
NumeroDocumento varchar(12) not null,
TipoDocumento int not null,
Direccion nvarchar not null,
Telefono nvarchar not null,
Email nvarchar not null,
NombreUsuario nvarchar not null,
Password nvarchar not null
)

alter table Suscripcion add constraint FK_Suscripcion_Suscriptor
foreign key(IdSuscriptor) references Suscriptor(IdSuscriptor)