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
Nombre varchar(50) not null,
Apellido varchar(50) not null,
NumeroDocumento varchar(8) not null,
TipoDocumento nvarchar not null,
Direccion nvarchar not null,
Telefono nvarchar not null,
Email nvarchar not null,
NombreUsuario nvarchar not null,
Password nvarchar not null
)

alter table Suscripcion add constraint FK_Suscripcion_Suscriptor
foreign key(IdSuscriptor) references Suscriptor(IdSuscriptor)