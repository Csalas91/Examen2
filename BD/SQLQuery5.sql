Create DATABASE CesarSalas

GO

use CesarSalas
go

CREATE TABLE Usuarios
(
ID int identity (1,1),
Nombre varchar(50) not null,
Email varchar (50) null,
Telefono varchar(15) Unique,
CONSTRAINT pk_ID_Usuario PRIMARY KEY(ID)
)

go
INSERT INTO Usuarios (Nombre, Email, Telefono) VALUES ('Cesar salas', 'c,jimenez@example.com', '123456789');
 INSERT INTO Usuarios (Nombre, Email, Telefono) VALUES ('Juan Orozco', 'J.Orozco@example.com', '987654321');
select * from Usuarios

CREATE TABLE Equipo
(
Codigo_Equipo int identity(1,1),
ID_Usuario int,
Tipo_Equipo varchar (50) not null,
Modelo varchar(50),
CONSTRAINT PK_ID_Equipo PRIMARY KEY(Codigo_Equipo),
CONSTRAINT FK_ID_Usuario foreign key(ID_Usuario) REFERENCES Usuarios(ID)

)


INSERT INTO Equipo (ID_Usuario, Tipo_Equipo, Modelo) VALUES (1, 'Laptop', 'ModeloX');
select * from Equipo
INSERT INTO Equipo (ID_Usuario, Tipo_Equipo, Modelo) VALUES (2, 'Laptop', 'ModeloY');
GO

CREATE TABLE Reparaciones
(
Codigo_Reparacion int identity (1,1),
ID_Equipo int,
Fecha_solcitud DATETIME,
Estado char (1),
CONSTRAINT PK_ID_Reparacion PRIMARY KEY(Codigo_Reparacion),
CONSTRAINT FK_ID_Equipo FOREIGN KEY(ID_Equipo) REFERENCES Equipo(Codigo_Equipo)


)
GO

CREATE TABLE DetallesReparacion
(
Codigo_Reparacion int identity(1,1),
ID_Detalles int,
Descripcion VARCHAR(50),
Fecha_Inicio DATETIME,
Fecha_Fin DATETIME,
CONSTRAINT PK_ID_DETALLES PRIMARY KEY(Codigo_Reparacion),
CONSTRAINT FK_ID_Detalles FOREIGN KEY (ID_Detalles) REFERENCES Reparaciones(Codigo_Reparacion)
)

GO

CREATE TABLE Tecnicos
(
Codigo_Tecnico int identity,
Nombre Varchar (50),
Especialidad varchar (50),
CONSTRAINT PK_ID_Tecnico PRIMARY KEY (Codigo_Tecnico)
)

INSERT INTO Tecnicos (Nombre, Especialidad) VALUES ('Alejandro', 'Redes');
select * from Tecnicos
GO

CREATE TABLE Asignaciones 
(
Codigo_Asignacion int identity,
Fecha_Asignacion DATETIME,
ID_Detalle int,
ID_Tecnico int,
CONSTRAINT PK_ID_Asignacion PRIMARY KEY(Codigo_Asignacion),
CONSTRAINT FK_ID_Detalle FOREIGN KEY (ID_Detalle) REFERENCES Reparaciones(Codigo_Reparacion),
CONSTRAINT FK_ID_Tecnico FOREIGN KEY (ID_Tecnico) REFERENCES Tecnicos(Codigo_Tecnico)	
)
GO

CREATE PROCEDURE Consultar_Filtro
@Codigo int
AS
BEGIN

SELECT * FROM Usuarios WHERE ID= @Codigo
SELECT * FROM Equipo WHERE Codigo_Equipo= @Codigo
SELECT * FROM Tecnicos WHERE Codigo_Tecnico= @Codigo

END

EXEC Consultar_Filtro 3

create PROCEDURE BorrarUsuarios
	@Codigo int
AS

BEGIN

DELETE Usuarios WHERE ID= @Codigo

END
create PROCEDURE BorrarTecnico
	@Codigo int
AS

BEGIN

DELETE Tecnicos WHERE Codigo_Tecnico= @Codigo

END
create PROCEDURE BorrarEquipo
	@Codigo int
AS

BEGIN

DELETE Equipo WHERE Codigo_Equipo= @Codigo

END
CREATE PROCEDURE ActualizarUsuario
    @ID INT,
    @Nombre VARCHAR(50),
    @Email VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        Email = @Email,
        Telefono = @Telefono
    WHERE ID = @ID;
END




CREATE PROCEDURE ActualizarTecnico
    @Codigo int,
    @Nombre varchar(50),
    @Especialidad varchar(50)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE Codigo_Tecnico = @Codigo;
END



CREATE PROCEDURE ActualizarEquipo
    @Codigo int,
    @ID_Usuario int,
    @Tipo_Equipo VARCHAR(50),
    @Modelo VARCHAR(50)
AS
BEGIN
    UPDATE Equipo
    SET ID_Usuario = @ID_Usuario,
        Tipo_Equipo = @Tipo_Equipo,
        Modelo = @Modelo
    WHERE Codigo_Equipo = @Codigo;
END


Create PROCEDURE Consultar 
AS
BEGIN
    SELECT * FROM Usuarios
	
END;


Create PROCEDURE ConsultarTecnico 
AS
BEGIN
    SELECT * FROM Tecnicos
	
END;


Create PROCEDURE ConsultarEquipo 
AS
BEGIN
    SELECT * FROM Equipo
	
END;
Exec  Consultar



CREATE PROCEDURE AgregarTecnico
   @Nombre varchar(50),
   @Especialidad VARCHAR(50)
AS
BEGIN
   
    INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@Nombre, @Especialidad);
END;
go


EXEC Consultar

CREATE PROCEDURE AgregarUsuario
	@Nombre VARCHAR(50),
    @Email VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono);
    
END
go
EXEC AgregarUsuario
	@Nombre = 'Juan', 
    @Email = 'J.Pacheco90@hotmail.com', 
    @Telefono = '55889998999999'

 CREATE PROCEDURE AgregarEquipo
	@ID_Usuario int,
    @Tipo_Equipo VARCHAR(50),
    @Modelo VARCHAR(50)
AS
BEGIN
    INSERT INTO Equipo (ID_Usuario, Tipo_Equipo, Modelo) VALUES (@ID_Usuario, @Tipo_Equipo, @Modelo);
END
go
EXEC AgregarEquipo
	 @ID_Usuario= '1', 
     @Tipo_Equipo='laptop', 
	 @Modelo='HP'
Exec ConsultarEquipo
