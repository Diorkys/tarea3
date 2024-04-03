create database crud_capas;
use crud_capas

create table Persona (
id int identity primary key not null,
nombre varchar (100),
apellido varchar (100),
direccion varchar (150),
fecha_nacimiento date,
celular varchar (50)

);
SELECT * FROM Persona

