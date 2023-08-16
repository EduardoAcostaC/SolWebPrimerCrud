CREATE DATABASE Generacion22;
USE Generacion22;

CREATE TABLE Alumnos(
	idAlumno INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(100),
	apellidoPaterno VARCHAR(100),
	apellidoMaterno VARCHAR(100) NOT NULL,
	Edad INT
);

SELECT * FROM Alumnos;

-- INSERTAR
INSERT INTO Alumnos (Nombre, apellidoPaterno, apellidoMaterno, Edad)
VALUES ('Eduardo', 'Acosta', 'Castillo', 21);

--INSERTAR SIN ESPECIFICAR COLUMNAS **NO SE RECOMIENDA
INSERT INTO Alumnos VALUES('Jose', 'Robles', 'Castro', 22);

--INSERANTO EN OTRO ORDEN
INSERT INTO Alumnos (Edad, apellidoMaterno,apellidoPaterno,Nombre)
VALUES (25, 'Contreras', 'Perez', 'Saul');

--INSERTANDO MULTIPLES REGISTROS
INSERT INTO Alumnos (Nombre, apellidoPaterno, apellidoMaterno,Edad)
VALUES ('Antonio', 'Lopez', 'SantaAna',32),
	('Ana', 'Lopez', 'Cortes',23),
	('Carlos', 'Osmar', 'Robles',21);

UPDATE Alumnos SET apellidoMaterno = 'Castro'
WHERE idAlumno = 5;

DELETE Alumnos
WHERE idAlumno = 6;

TRUNCATE TABLE Alumnos;

SELECT idAlumno, Nombre, apellidoPaterno, apellidoMaterno, Edad FROM Alumnos;

SELECT idAlumno, Nombre, apellidoPaterno, apellidoMaterno, Edad 
FROM Alumnos WHERE idAlumno=6;

UPDATE Alumnos SET Nombre='', apellidoPaterno='', apellidoMaterno='', Edad=
WHERE idAlumno=;

ALTER TABLE Alumnos ADD Correo VARCHAR(100);

INSERT INTO Alumnos (Nombre, apellidoPaterno, apellidoMaterno, Edad, Correo)
VALUES ('Eduardo', 'Acosta', 'Castillo', 21, 'correo@correo.com.mx');