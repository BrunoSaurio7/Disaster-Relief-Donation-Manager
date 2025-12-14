use Proyecto1

create table Desastre
	(cDesastre int primary key identity,
	Nombre varchar(100) not null)

create table Estado
	(cEstado int primary key identity,
	Nombre varchar(100) not null)

create table Ciudad
	(cCiudad int primary key identity,
	cEstado int references Estado,
	Nombre varchar(100) not null)

create table Siniestro
	(cSiniestro int primary key identity,
	Nombre varchar(100) not null,
	cCiudad int references Ciudad,
	cDesastre int references Desastre)

create table Persona
	(cPersona int primary key identity,
	Nombre varchar(100) not null,
	cCiudad int references Ciudad,
	Correo varchar(100) not null)

drop table Afecta

create table Afecta
	(cPersona int references Persona,
	cSiniestro int references Siniestro,
	Fecha varchar(100) not null,
	primary key(cPersona,cSiniestro,fecha))

create table Donacion
	(cDonacion int primary key identity,
	Fecha varchar(100) not null,
	cPersona int references Persona)

create table Insumo
	(cInsumo int primary key identity,
	Nombre varchar(100) not null)

create table TieneDonacion
	(cDonacion int references Donacion,
	cInsumo int references Insumo,
	Cantidad int not null,
	primary key(cDonacion,cInsumo))

drop table CentroAcopio
create table CentroAcopio
	(cCentro int primary key identity,
	Nombre varchar(100) not null,
	Direccion varchar(100) not null,
	cCiudad int references Ciudad)

drop table TieneCentroAcopio
create table TieneCentroAcopio
	(cCentro int references CentroAcopio,
	cInsumo int references Insumo,
	Inventario int,
	primary key(cCentro,cInsumo))

create table Recibe
	(cCentroAcopio int references CentroAcopio,
	cDonacion int references Donacion,
	primary key(cCentroAcopio,cDonacion))

create table Administrador
	(cAdmin int primary key identity,
	Nombre varchar(100) not null,
	Correo varchar(100) not null,
	Contraseña varchar(100) not null)

INSERT INTO Desastre (Nombre) VALUES 
('Terremoto'), ('Huracán'), ('Inundación'), 
('Incendio Forestal'), ('Erupción Volcánica'), 
('Sequía'), ('Tsunami'), ('Derrumbe'), 
('Tormenta Eléctrica'), ('Frente Frío');

INSERT INTO Estado (Nombre) VALUES 
('Ciudad de México'), ('Jalisco'), ('Nuevo León'), 
('Chiapas'), ('Veracruz'), ('Guerrero'), 
('Baja California'), ('Oaxaca'), 
('Puebla'), ('Tabasco');

INSERT INTO Ciudad (cEstado, Nombre) VALUES 
(1, 'Coyoacán'), (1, 'Iztapalapa'), 
(2, 'Guadalajara'), (2, 'Puerto Vallarta'), 
(3, 'Monterrey'), (4, 'Tuxtla Gutiérrez'), 
(5, 'Veracruz'), (6, 'Acapulco'), 
(7, 'Tijuana'), (8, 'Oaxaca de Juárez');

INSERT INTO Siniestro (Nombre, cCiudad, cDesastre) VALUES 
('Terremoto en CDMX', 1, 1), 
('Huracán Patricia', 2, 2), 
('Inundación en Villahermosa', 5, 3), 
('Incendio en Sierra Madre', 5, 4), 
('Erupción del Popocatépetl', 6, 5), 
('Sequía en Oaxaca', 10, 6), 
('Tsunami en Ensenada', 9, 7), 
('Derrumbe en Guerrero', 8, 8), 
('Tormenta Eléctrica en CDMX', 2, 9), 
('Frente Frío en Tuxtla', 6, 10);

INSERT INTO Persona (Nombre, cCiudad, Correo) VALUES 
('Carlos Pérez', 1, 'carlos@gmail.com'), 
('María Gómez', 4, 'maria@gmail.com'), 
('José Hernández', 7, 'jose@outlook.com'), 
('Ana Martínez', 5, 'ana@yahoo.com'), 
('Jorge López', 9, 'jorge@gmail.com'), 
('Paula Ramírez', 8, 'paula@gmail.com'), 
('Luis Torres', 10, 'luis@gmail.com'), 
('Sofía Ortiz', 6, 'sofia@gmail.com'), 
('David Sánchez', 2, 'david@hotmail.com'), 
('Elena Rivas', 3, 'elena@gmail.com');

INSERT INTO Afecta (cPersona, cSiniestro, Fecha) VALUES 
(1, 1, '2024-01-15'), (2, 2, '2024-02-20'), 
(3, 3, '2024-03-10'), (4, 4, '2024-04-12'), 
(5, 5, '2024-05-05'), (6, 6, '2024-06-01'), 
(7, 7, '2024-07-25'), (8, 8, '2024-08-19'), 
(9, 9, '2024-09-11'), (10, 10, '2024-10-01');

INSERT INTO Donacion (Fecha, cPersona) VALUES 
('2024-01-16', 1), ('2024-02-21', 2), 
('2024-03-11', 3), ('2024-04-13', 4), 
('2024-05-06', 5), ('2024-06-02', 6), 
('2024-07-26', 7), ('2024-08-20', 8), 
('2024-09-12', 9), ('2024-10-02', 10);

INSERT INTO Insumo (Nombre) VALUES 
('Agua embotellada'), ('Alimentos enlatados'), 
('Mantas'), ('Medicamentos'), 
('Kit de primeros auxilios'), ('Ropa'), 
('Herramientas'), ('Gasolina'), 
('Productos de higiene'), ('Colchonetas');

INSERT INTO TieneDonacion (cDonacion, cInsumo, Cantidad) VALUES 
(1, 1, 50), (2, 2, 30), 
(3, 3, 100), (4, 4, 25), 
(5, 5, 10), (6, 6, 60), 
(7, 7, 15), (8, 8, 20), 
(9, 9, 40), (10, 10, 50);

INSERT INTO CentroAcopio (Nombre, Direccion, cCiudad) VALUES
('Centro Acopio Coyoacán', 'Av. Miguel Ángel de Quevedo 123, Coyoacán, CDMX', 1),
('Centro Acopio Iztapalapa', 'Calzada Ermita Iztapalapa 456, Iztapalapa, CDMX', 2),
('Centro Acopio Guadalajara', 'Av. Chapultepec 789, Guadalajara, Jalisco', 3),
('Centro Acopio Vallarta', 'Blvd. Francisco Medina Ascencio 101, Puerto Vallarta, Jalisco', 4),
('Centro Acopio Monterrey', 'Av. Constitución 202, Monterrey, Nuevo León', 5),
('Centro Acopio Tuxtla', 'Blvd. Ángel Albino Corzo 303, Tuxtla Gutiérrez, Chiapas', 6),
('Centro Acopio Veracruz', 'Malecón Av. Manuel Ávila Camacho 404, Veracruz, Veracruz', 7),
('Centro Acopio Acapulco', 'Av. Costera Miguel Alemán 505, Acapulco, Guerrero', 8),
('Centro Acopio Tijuana', 'Av. Revolución 606, Tijuana, Baja California', 9),
('Centro Acopio Oaxaca', 'Calzada de la República 707, Oaxaca de Juárez, Oaxaca', 10);

INSERT INTO TieneCentroAcopio (cCentro, cInsumo, Inventario) VALUES 
(1, 1, 100), (2, 2, 200), 
(3, 3, 150), (4, 4, 80), 
(5, 5, 50), (6, 6, 120), 
(7, 7, 30), (8, 8, 40), 
(9, 9, 100), (10, 10, 75);

INSERT INTO Recibe (cCentroAcopio, cDonacion) VALUES 
(1, 1), (2, 2), (3, 3), 
(4, 4), (5, 5), (6, 6), 
(7, 7), (8, 8), (9, 9), 
(10, 10);

INSERT INTO Administrador (Nombre,Correo,Contraseña) values
('Juan','juan@gmail.com','juanito'), ('Moisés','moises@gmail.com','moi'),
('Abi','abi@gmail.com','abi'), ('Miguel','miguel@gmail.com','miguelito'),
('José','jose@gmail.com','pepe'), ('Mario','mario@gmail.com','mario');


select * from Administrador


select * from Ciudad

select * from CentroAcopio
select * from TieneCentroAcopio

select CentroAcopio.Nombre from (CentroAcopio inner join TieneCentroAcopio on CentroAcopio.cCentro=TieneCentroAcopio.cCentro) where cCiudad=1 and cInsumo in (1,2,3)

select * from Donacion
select * from TieneDonacion
select * from Recibe
select * from TieneCentroAcopio

select Donacion.cDonacion from Donacion where cDonacion=()

select MAX(Donacion.cDonacion) from Donacion

insert into TieneDonacion values((select MAX(Donacion.cDonacion) from Donacion),2,50)

delete from TieneDonacion where cDonacion='10' and cInsumo='2'


select TieneCentroAcopio.Inventario from TieneCentroAcopio where cCentro='1' and cInsumo='1'


select * from Desastre
select Desastre.Nombre from Desastre where Desastre.Nombre like 'terremoto'

delete from Afecta where Afecta.cSiniestro in (select Siniestro.cSiniestro from (Desastre inner join Siniestro on Desastre.cDesastre=Siniestro.cSiniestro) where Desastre.cDesastre=1)
delete from Siniestro where Siniestro.cDesastre=1
delete from Desastre where Desastre.cDesastre=1

select Siniestro.cSiniestro from (Desastre inner join Siniestro on Desastre.cDesastre=Siniestro.cSiniestro) where Desastre.cDesastre=1

select * from Siniestro

delete from Afecta where cSiniestro=1
delete from Siniestro where cSiniestro=1