--MOSTRAR DATOS

CREATE PROC SP_Mostrar
AS
SELECT * FROM Persona


use crud_capas



--insertar datos

CREATE PROC SP_Insertar
@id int,
@nombre varchar (100),
@apellido varchar (100),
@direccion varchar (150),
@fecha_nacimiento date,
@celular varchar (50)
AS
INSERT INTO Persona ( nombre, apellido, direccion, fecha_nacimiento, celular)
VALUES ( @nombre, @apellido, @direccion, @fecha_nacimiento, @celular);
GO





--MODIFICAR
CREATE PROC SP_Modificar
@id int,
@nombre varchar (100),
@apellido varchar (100),
@direccion varchar (150),
@fecha_nacimiento date,
@celular varchar (50)
AS
UPDATE Persona SET nombre = @nombre, apellido = @apellido, direccion = @direccion, fecha_nacimiento = @fecha_nacimiento, celular = @celular
where id = @id
GO



--ELIMINAR
CREATE PROC SP_Eliminar
@id int 
AS
DELETE Persona WHERE id = @id
GO



--BUSCAR DATOS

CREATE PROC SP_Buscar
@Buscar NVARCHAR (30)
AS
SELECT * FROM Persona WHERE nombre like @Buscar + '%'
GO



