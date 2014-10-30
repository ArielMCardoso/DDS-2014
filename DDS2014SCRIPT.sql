CREATE TABLE Persona ( 	
	ID_Persona numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	DNI numeric(18) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Apellido nvarchar(255) NOT NULL,	
	Mail nvarchar(255) NOT NULL);
	

CREATE TABLE Jugador ( 
	ID_Jugador numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),	
	ID_Persona numeric(18) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,		
	Telefono nvarchar(50) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Apodo nvarchar(50) NOT NULL,
	Handicap nvarchar(255) NOT NULL,
	FOREIGN KEY (ID_Persona) REFERENCES Persona (ID_Persona));
	

CREATE TABLE Amigo ( 
	ID_Jugador numeric(18) NOT NULL,	
	ID_Persona numeric(18) NOT NULL,
	FOREIGN KEY (ID_Jugador) REFERENCES Jugador (ID_Jugador),
	FOREIGN KEY (ID_Persona) REFERENCES Persona (ID_Persona));	


CREATE TABLE Equipo ( 
	ID_Equipo numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),	
	ID_Jugador1 numeric(18),	
	ID_Jugador2 numeric(18),
	ID_Jugador3 numeric(18),
	ID_Jugador4 numeric(18),
	ID_Jugador5 numeric(18));
	
	
CREATE TABLE Estado ( 
	ID_Estado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);


CREATE TABLE Administrador (
	ID_Administrador numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);	
	
	
CREATE TABLE Criterio_Orden ( 
	ID_Orden numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Cantidad_Partidos numeric(18));
		
	
CREATE TABLE Criterio_Division ( 
	ID_Division numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);			
		
	
CREATE TABLE Partido ( 
	ID_Partido numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Fecha datetime NOT NULL,
	ID_Estado numeric(18) NOT NULL,
	ID_Division numeric(18),
	ID_Orden numeric(18),
	ID_Equipo1 numeric(18),	
	ID_Equipo2 numeric(18),
	ID_Administrador numeric(18) NOT NULL,	
	FOREIGN KEY (ID_Division) REFERENCES Criterio_Division (ID_Division),
	FOREIGN KEY (ID_Orden) REFERENCES Criterio_Orden (ID_Orden),
	FOREIGN KEY (ID_Equipo1) REFERENCES Equipo (ID_Equipo),
	FOREIGN KEY (ID_Equipo2) REFERENCES Equipo (ID_Equipo),
	FOREIGN KEY (ID_Administrador) REFERENCES Administrador (ID_Administrador),
	FOREIGN KEY (ID_Estado) REFERENCES Estado (ID_Estado));	
	
	
CREATE TABLE Penalizacion ( 
	ID_Penalizacion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255),
	Fecha datetime NOT NULL,
	Dias_Duracion numeric(18) NOT NULL,	
	ID_Jugador numeric(18) NOT NULL,
	FOREIGN KEY (ID_Jugador) REFERENCES Jugador (ID_Jugador));
	
	
CREATE TABLE Calificacion ( 
	ID_Calificacion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Puntaje numeric(18) NOT NULL,	
	Critica nvarchar(255),
	ID_Calificador numeric(18) NOT NULL,
	ID_Calificado numeric(18) NOT NULL,
	ID_Partido numeric(18) NOT NULL,
	FOREIGN KEY (ID_Calificador) REFERENCES Jugador (ID_Jugador),
	FOREIGN KEY (ID_Calificado) REFERENCES Jugador (ID_Jugador),
	FOREIGN KEY (ID_Partido) REFERENCES Partido (ID_Partido));	
	
	
CREATE TABLE Tipo_Inscripcion ( 
	ID_Tipo_Inscripcion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Condicion nvarchar(255));	

	
CREATE TABLE Inscripcion ( 
	ID_Inscripcion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	ID_Partido numeric(18) NOT NULL,
	ID_Jugador numeric(18) NOT NULL,
	ID_Tipo_Inscripcion numeric(18) NOT NULL,	
	ID_Estado numeric(18) NOT NULL,
	FOREIGN KEY (ID_Partido) REFERENCES Partido (ID_Partido),
	FOREIGN KEY (ID_Jugador) REFERENCES Jugador (ID_Jugador),
	FOREIGN KEY (ID_Tipo_Inscripcion) REFERENCES Tipo_Inscripcion (ID_Tipo_Inscripcion),
	FOREIGN KEY (ID_Estado) REFERENCES Estado (ID_Estado));
	
GO

SET DATEFORMAT YMD

--Criterios de Division:
INSERT INTO Criterio_Division (Nombre) VALUES ('Paridad');
INSERT INTO Criterio_Division (Nombre) VALUES ('14589');

select * from Criterio_Division

--Criterios de Orden:
INSERT INTO Criterio_Orden (Nombre) VALUES ('Por Handicap');
INSERT INTO Criterio_Orden (Nombre) VALUES ('Promedio Ultimo Partido');
INSERT INTO Criterio_Orden (Nombre,Cantidad_Partidos) VALUES ('Promedio Ultimos N Partidos',5);
INSERT INTO Criterio_Orden (Nombre,Cantidad_Partidos) VALUES ('Mix',8);

select * from Criterio_Orden

--Estados:
INSERT INTO Estado(Nombre) VALUES ('No Confirmado');
INSERT INTO Estado(Nombre) VALUES ('Confirmado');
INSERT INTO Estado(Nombre) VALUES ('Jugando');
INSERT INTO Estado(Nombre) VALUES ('Jugado');
INSERT INTO Estado(Nombre) VALUES ('Super Confirmado');

select * from Estado

--Tipos de Inscripcion:
INSERT INTO Tipo_Inscripcion(Descripcion) VALUES ('Estandar');
INSERT INTO Tipo_Inscripcion(Descripcion) VALUES ('Solidaria');
INSERT INTO Tipo_Inscripcion(Descripcion,Condicion) VALUES ('Condicional','Que haga mas de 25ºC');

select * from Tipo_Inscripcion

GO

--Personas:
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Brian','Leder',36000000,'doctorbleder@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Matias','Castiglioni',36000001,'casty@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Federico','Fernandez',39000001,'yomellamofede@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Nicolas','Rey',36000007,'chino_rey@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Lautaro','Fernandez',36000009,'lautarogfernandez@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Ariel','Cardoso',36000011,'ariel@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Diego','Piedrafita',36000077,'pola7@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Nahuel','Arancibia',36000088,'nahue@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Pablo','Casado',36000089,'pablito@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Gonzalo','Laredo',36000090,'gonzalarrrrredo@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Federico','De Grazia',36000091,'fede@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Gabriel','Di ccucio',12141111,'gab_d@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Victor Manuel','Vicente',11128234,'vicent@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Robert','Langdon',27829024,'land@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('John','Watson',35001241,'wat@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Facundo','Ferreyra',32143701,'facu@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Ismael','Perez',17972208,'ismi@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Sandro','Botichelli',42138501,'boti@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Rafael','Santi',22403978,'santi@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Santiago','Linutti',30128100,'linu@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Robert','Opehammer',33456570,'pum@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Victor','Hugo',23451234,'toridio@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Helder','Harker',49873212,'har@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Mario','Delen',49873212,'del@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Brand','Stoker',45234123,'stok@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('James','Bond',32456781,'seven@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('George','Orwell',43567128,'orwi@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Eric','Blair',43523478,'orwel77@gmail.com');
INSERT INTO Persona(Nombre,Apellido,DNI,Mail) VALUES ('Oscar','Wilde',45672840,'willi8@gmail.com');

select * from Persona

--Jugadores:
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (7,CONVERT(datetime,'1992-09-01',111),'Diaz Velez 1111','4444-8888',10,'Pola');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (5,CONVERT(datetime,'1992-10-22',111),'Indepencia 331','4444-5555',5,'Laucha');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (4,CONVERT(datetime,'1992-07-25',111),'Morelos 10','4444-3987',3,'Chino');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (2,CONVERT(datetime,'1992-11-10',111),'El Pasaje Donde Vive Casty 77','9012-3987',1,'Casty');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (8,CONVERT(datetime,'1993-01-05',111),'No sé 123','5612-2390',10,'Nahue');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (10,CONVERT(datetime,'1993-05-10',111),'Nazca 2345','4356-0987',1,'El pela');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (16,CONVERT(datetime,'1994-05-10',111),'Jonte 4902','4030-3456',8,'Galgo');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (17,CONVERT(datetime,'1994-02-28',111),'Paraguay 2232','4584-5120',3,'Para');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (19,CONVERT(datetime,'1993-05-01',111),'Uruguay 3001','4094-2351',7,'Pichi');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (20,CONVERT(datetime,'1944-06-07',111),'Juan A. Garcia 3245','4721-4591',5,'Pocho');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (21,CONVERT(datetime,'1945-08-06',111),'Medrano 951','4901-4356',2,'Roli');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (22,CONVERT(datetime,'1944-06-09',111),'Bolivar 2345','7890-6783',3,'Chuchi');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (23,CONVERT(datetime,'1995-06-07',111),'Boliar 3418','4356-5678',5,'Tincho');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (24,CONVERT(datetime,'1980-06-07',111),'Bilinghust 6578','4512-9834',9,'Topo');
INSERT INTO Jugador(ID_Persona,Fecha_Nacimiento,Direccion,Telefono,Handicap,Apodo) VALUES (25,CONVERT(datetime,'1981-06-07',111),'Gavilan 3248','4562-3498',2,'Pitu');																
								

select j.ID_Jugador, p.Nombre, p.Apellido, p.DNI, j.Fecha_Nacimiento, j.Direccion,j.Telefono,j.Handicap, p.Mail, j.Apodo
from Jugador j join Persona p on (p.ID_Persona=j.ID_Persona)

--Amigos
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,2);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,3);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,4);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,6);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,7);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (2,8);
INSERT INTO Amigo (ID_Jugador,ID_Persona) VALUES (1,8);

select * from Amigo

select p1.Nombre AS 'NOMBRE 1', p1.Apellido AS 'APELLIDO 1', p2.Nombre AS 'NOMBRE 2', p2.Apellido AS 'APELLIDO 2'
from Jugador j join Persona p1 on (p1.ID_Persona=j.ID_Persona)
			   join Amigo a on (a.ID_Jugador=j.ID_Jugador)
			   join Persona p2 on (p2.ID_Persona=a.ID_Persona)

--Equipos
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (1,2,3,4,5);																
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (6,7,8,9,10);
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (5,7,8,9,12);																
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (10,2,3,4,13);			
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (11,10,8,9,15);		
INSERT INTO Equipo(ID_Jugador1,ID_Jugador2,ID_Jugador3,ID_Jugador4,ID_Jugador5) VALUES (15,12,2,1,5);	

select	 * from Equipo

--Administrador
INSERT INTO Administrador(Nombre) VALUES ('Carlitos');

select * from Administrador

--Partidos
INSERT INTO Partido(Fecha,ID_Division,ID_Orden,ID_Equipo1,ID_Equipo2,ID_Administrador,ID_Estado) VALUES (CONVERT(datetime,'2014-10-30',111),1,3,1,2,1,4);
INSERT INTO Partido(Fecha,ID_Division,ID_Orden,ID_Equipo1,ID_Equipo2,ID_Administrador,ID_Estado) VALUES (CONVERT(datetime,'2014-10-31',111),2,1,3,4,1,4);
INSERT INTO Partido(Fecha,ID_Division,ID_Orden,ID_Equipo1,ID_Equipo2,ID_Administrador,ID_Estado) VALUES (CONVERT(datetime,'2014-11-11',111),2,2,5,6,1,5);

select * from Partido


--Calificaciones
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,2,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,3,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,4,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,5,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,6,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,8,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,9,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,1,10,6,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,1,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,3,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,4,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,5,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,6,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,8,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,9,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,2,10,5,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,1,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,2,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,4,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,5,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,6,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,7,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,8,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,9,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,3,10,5,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,1,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,3,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,2,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,5,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,6,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,8,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,9,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,4,10,3,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,1,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,3,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,4,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,2,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,6,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,8,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,9,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,5,10,5,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,1,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,3,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,4,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,2,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,5,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,8,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,9,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,6,10,1,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,1,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,3,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,4,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,2,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,6,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,5,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,8,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,9,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,7,10,4,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,1,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,3,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,4,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,2,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,6,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,7,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,5,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,9,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,8,10,10,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,1,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,3,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,4,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,2,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,6,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,7,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,8,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,5,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,9,10,4,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,1,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,4,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,2,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,6,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,7,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,8,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,9,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (1,10,5,2,'Nada');

INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,7,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,8,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,9,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,12,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,10,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,2,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,4,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,5,13,5,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,5,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,8,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,9,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,12,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,10,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,2,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,3,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,4,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,7,13,2,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,7,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,5,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,9,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,12,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,10,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,2,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,3,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,4,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,8,13,2,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,7,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,8,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,5,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,12,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,10,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,2,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,4,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,9,13,9,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,7,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,8,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,9,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,5,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,10,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,2,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,3,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,4,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,12,13,5,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,7,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,8,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,9,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,12,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,5,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,2,6,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,4,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,10,13,4,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,7,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,8,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,9,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,12,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,10,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,5,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,4,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,2,13,8,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,7,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,8,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,9,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,12,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,10,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,2,2,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,5,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,4,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,3,13,5,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,7,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,8,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,9,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,12,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,10,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,2,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,5,4,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,4,13,4,'Nada');


INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,7,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,8,5,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,9,7,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,12,9,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,10,3,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,2,1,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,3,10,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,4,8,'Nada');
INSERT INTO Calificacion(ID_Partido,ID_Calificador,ID_Calificado,Puntaje,Critica) VALUES (2,13,5,5,'Nada');

select * from Calificacion c
order by 	c.ID_Partido, c.ID_Calificado, c.ID_Calificador,c.Puntaje

INSERT INTO Penalizacion(Descripcion,Fecha,Dias_Duracion,ID_Jugador) VALUES ('Por golpear al arbitro',CONVERT(datetime,'2014-10-31',111),7,13);
INSERT INTO Penalizacion(Descripcion,Fecha,Dias_Duracion,ID_Jugador) VALUES ('Por bajarle los pantalones a un compañero',CONVERT(datetime,'2014-10-31',111),10,3);
INSERT INTO Penalizacion(Descripcion,Fecha,Dias_Duracion,ID_Jugador) VALUES ('Por decir groserías',CONVERT(datetime,'2014-10-31',111),10,4);

select * from Penalizacion	

GO







DROP TABLE Partido;	
DROP TABLE Jugador;
DROP TABLE Equipo;
DROP TABLE Estado;
DROP TABLE Administrador;
DROP TABLE Criterio_Orden;	
DROP TABLE Criterio_Division;
DROP TABLE Tipo_Inscripcion;
DROP TABLE Persona;
DROP TABLE Amigo;
DROP TABLE Penalizacion;
DROP TABLE Calificacion;	
DROP TABLE Inscripcion;
GO