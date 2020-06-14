/*Creamos la tabla cliente*/
create table Cliente
(
Cliente_id varchar2(12) not null,
PrimerNombre varchar2(15) not null,
SegundoNombre varchar2(15) not null,
PrimerApellido varchar2(15) not null,
SegundoApellido varchar2(15) not null,
Barrio varchar2(15) not null,
Ciudad varchar2(15) not null,
Comuna varchar2(3)  null,
N_Casa varchar2(15) not null,
Telefono varchar(10) not null
);
 
 alter table cliente
  add Email varchar2(20)  null;
   alter table cliente
  modify Email varchar2(30)  null;
 /*Creamos la llave primaria del cliente*/
 ALTER TABLE Cliente ADD constraint pk_Cliente_id PRIMARY KEY (Cliente_id);
 
 /*Creamos la tabla trabajador*/
 create table Trabajador
(
Trabajador_id varchar2(12) not null,
PrimerNombre varchar2(15) not null,
SegundoNombre varchar2(15) not null,
PrimerApellido varchar2(15) not null,
SegundoApellido varchar2(15) not null,
Telefono varchar(10) not null,
Cargo varchar(20) not null
);

 
 alter table trabajador
  add Email varchar2(30)  null;
 /*Creamos la llave primaria del Travajador*/
 ALTER TABLE Trabajador ADD constraint pk_Trabajador_id PRIMARY KEY (Trabajador_id);

 /*Creamos la tabla Proveedor*/
 create table Proveedor
(
Rut varchar2(12) not null,
Nombre_Comercial varchar2(15) not null,
Telefono varchar(10) not null
);
 /*Creamos la llave primaria del Proveedor*/
 ALTER TABLE Proveedor ADD constraint pk_Rut PRIMARY KEY (Rut);
 
 create table Productos
(
Productos_id  varchar2(12) not null,
nombre VARCHAR2(20) not null,
Descripcion VARCHAR2(40)  null,
precio_venta number(15,2) not null,
precio_costo number(15,2) not null,
Iva number(15,2) not null,
tipo varchar(15) not null,
modelo VARCHAR2(15)  null,
cantidad int not null
);

select *from productos;
  alter table Productos
  modify Iva double  null;
delete from productos;
 alter table productos
  add Existencia int not null;
     alter table productos
  modify Descripcion varchar2(80)  null;
INSERT INTO productos values('001','llantas','llantas para motos de alta velocidad','50000','67000','19','Repuestos','2020','1','1');
INSERT INTO productos values('002','frenos','frenos para moto boxer','70000','90000','19','Repuestos','2010','2','2');
INSERT INTO productos values('003','bujias','bujias para motos de cilindraje 100','10000','17000','19','Repuestos','2000','80','80');
INSERT INTO productos values('004','llantas','llantas para motos de baja velociada','40000','57000','19','Repuestos','2015','100','100');
INSERT INTO productos values('005','motor pulsar 200','motor de moto pulsar de cilindraje 200','4000000','5000000','19','Repuestos','2018','5','5');
INSERT INTO productos values('006','neumaticos','neumaticos 120/200 para cualquier modelo','10000','27000','19','Repuestos','2000','130','130');
INSERT INTO productos values('007','carburador','carburador de alta velocidad  para motos de 150 cc','500000','607000','19','Repuestos','2010','41','41');
INSERT INTO productos values('008','motor dicel','motor dicel para camionestas tollotas','7000000','70007000','19','Repuestos','2015','10','10');
INSERT INTO productos values('009','espejos retrovisores','retrovisores para mazda 323','30000','57000','19','Acesorios','2000','50','50');
INSERT INTO productos values('0010','llantas 4x4','llantas para carros todo terreno','900000','990000','19','Repuestos','2010','19','19');
select * from productos;
 ALTER TABLE Productos ADD constraint pk_Productos_id PRIMARY KEY (Productos_id);
commit
 /*Creamos la tabla Factura*/
create table Factura
(
Factura_id varchar2(12) not null,
Totales number(15,2) not null,
Fecha  DATE not null,
Cliente_id varchar2(12) not null,
FormaDePago varchar2(12) not null
);

delete from Factura;
select *from Factura;
select *from DetalleFactura;
delete from DetalleFactura;
commit
  /*Creamos la llave primaria de Factura*/
 ALTER TABLE Factura ADD constraint pk_Factura_id PRIMARY KEY (Factura_id);
 /*Creamos la llave Forane de Factura*/
 ALTER TABLE Factura
  ADD CONSTRAINT FK_Cliente_id
  FOREIGN KEY (Cliente_id)
  REFERENCES Cliente(Cliente_id);
  
  
create table DetalleFactura
(
DetalleFac_id varchar2(12) not null,
Producto_id varchar2(12) not null,
Nombre varchar2(12) not null,
Tipo varchar2(12) not null,
Precio_venta number(15,2),
Cantidad int not null,
Total  number(15,2) not null,
Factura_id varchar2(12) not null
);

DROP TABLE DetalleFactura CASCADE CONSTRAINT PURGE;
  select * from DetalleFactura;
 ALTER TABLE DetalleFactura ADD constraint pk_DetalleFac_id PRIMARY KEY (DetalleFac_id);
 
 ALTER TABLE DetalleFactura
  ADD CONSTRAINT FK_Factura_id
  FOREIGN KEY (Factura_id)
  REFERENCES Factura(Factura_id);
  
    ALTER TABLE DetalleFactura
  ADD CONSTRAINT FK_Productos_id
  FOREIGN KEY (Producto_id)
  REFERENCES Productos(Productos_id);
commit;
/*Insertamos registros a la tabla cliente*/
INSERT INTO cliente values('00001','ana','sofia','vega','ochoa','kenedy','valledupar','3','35-45','321148974','anasofia03@gmail.com');
INSERT INTO cliente values('00002','JHOAN','MILEYDIS','ROJAS','ALVAREZ','SANTOS','SANTA MARTA','5','45-75','3206578','jhon2039@gmail.com');
INSERT INTO cliente values('00003','LINA','sofia','ALVARES','PEREZ','SUBA','BOGOTA','3','70-09','30456758','linsofi323@gmail.com');
INSERT INTO cliente values('00004','RAFAEL','ALEJANDRO','PERZ','MARTINEZ','TORO','COPEY','4','65-45','98303444','rafael45@gmail.com');
INSERT INTO cliente values('00005','DAVID','LUIS','MARTIN','ACOSTA','PRIMERA-MAYO','valledupar','3','55-45','32065473','davie88@hotmail.com');
INSERT INTO cliente values('00006','TEREZA','sofia','MENDOZA','ochoa','PARIS','ESPAÑA','5','34-45','30576833','terezsoo09@gmail.com');
INSERT INTO cliente values('00007','GOKU','MATEO','ROMERO','ACUÑA','ESCORCIA','valledupar','1','23-35','324585445','goku18@hotmail.com');
INSERT INTO cliente values('00008','VEGETA','GOJAN','PEREZ','LUZ','NEVADA','valledupar','5','35-45','322987744','vegeta2009@gmail.com');
INSERT INTO cliente values('00009','PICORO','PARTIO','OCHOA','ochoa','PALMAS','valledupar','1','56-45','98089033','palmcoro33@gmail.com');
INSERT INTO cliente values('000010','PABLO','EMILIO','ESCOBAR','GABIRIA','MEDI','MEDELLIN','13','65-465','3245677','elpatron10@gmail.com');
 SELECT * FROM CLIENTE;
 delete from CLIENTE;
 /*Insertamos registros a la tabla Travjador*/
 INSERT INTO Trabajador values('1','Andres','antonio','Perez','oso','3205421213','vendedor','mayo','valledupar','1','23_45','andre23@gmail.com');
INSERT INTO Trabajador values('2','Jesus','Alfonso','Reyes','Torres','3232101112','vendedor','nevada','valledupar','2','22_40','jesrey@gmail.com');
INSERT INTO Trabajador values('3','Anastasia','Patricia','Alcantara','Riz','3008222222','vendedor','martin','valledupar','1','13_45','patriana43@gmail.com');
INSERT INTO Trabajador values('4','Jose','Guillen','Perez','Ronaldo','3012309293','Administrador','7 agosto','valledupar','5','50-80','jos344@gmail.com');
INSERT INTO Trabajador values('5','Andrea','Carolina','Castro','Imitola','3125842901','Bodegero','nevada','valledupar','1','23_49','iroanro2992@hotmail.com');
INSERT INTO Trabajador values('6','Iromaldis','Antonia','Perez','Pantoja','3008976543','vendedor','centro','valledupar','3','20_95','perePa@gmail.com');
INSERT INTO Trabajador values('7','Juan','Adrian','Zapata','Torres','3207654312','Mensajero','nevada','valledupar','5','45-87','juantor56@gmail.com');
INSERT INTO Trabajador values('8','Andres','Carlos','Perez','Reyes','3180123212','Mensajero','la popa','valledupar','3','34-45','carlopere@gmail.com');
 delete from Trabajador;
 SELECT * FROM cliente;

 /*Insertamos registros a la tabla Proveedor*/
INSERT INTO Proveedor values('1','Mazda','3205421213');
INSERT INTO Proveedor values('2','Yamaha','3008222222');
INSERT INTO Proveedor values('3','Hyunday','1258429012');
INSERT INTO Proveedor values('4','Zuzuki','3154678239');
INSERT INTO Proveedor values('5','Ford','3114567213');
INSERT INTO Proveedor values('6','Toyota','3245678097');
INSERT INTO Proveedor values('7','Audi','3124568231');
INSERT INTO Proveedor values('8','Ferrari','3125842901');
INSERT INTO Proveedor values('9','Hero','3124234567');
INSERT INTO Proveedor values('10','Kemword','3137654987');
 SELECT * FROM proveedor;

 /*Insertamos registros a la tabla Productos*/
INSERT INTO productos values('001','llantas','llantas para motos de alta velocidad','50000','67000','19','repuesos','2020','1');
INSERT INTO productos values('002','frenos','frenos para moto boxer','70000','90000','19','repuesos','2010','2');
INSERT INTO productos values('003','bujias','bujias para motos de cilindraje 100','10000','17000','19','repuesos','2000','80');
INSERT INTO productos values('004','llantas','llantas para motos de baja velociada','40000','57000','19','repuesos','2015','100');
INSERT INTO productos values('005','motor pulsar 200','motor de moto pulsar de cilindraje 200','4000000','5000000','19','repuesos','2018','5');
INSERT INTO productos values('006','neumaticos','neumaticos 120/200 para cualquier modelo','10000','27000','19','repuesos','2000','130');
INSERT INTO productos values('007','carburador','carburador de maxima aceleracion para motos de mas de 150 cc','500000','607000','19','repuesos','2010','41');
INSERT INTO productos values('008','motor dicel','motor dicel para camionestas tollotas','7000000','70007000','19','repuesos','2015','10');
INSERT INTO productos values('009','espejos retrovisores','retrovisores para mazda 323','30000','57000','19','repuesos','2000','50');
INSERT INTO productos values('0010','llantas 4x4','llantas para carros todo terreno','900000','990000','19','repuesos','2010','19');
select * from productos;

 /*Insertamos registros a la tabla Factura*/
INSERT INTO Factura values('1',20000,'24/05/2020','00001','Efectivo');
INSERT INTO Factura values('2',25000,'24/05/2020','00003','Tarjeta');
INSERT INTO Factura values('3',400500,'23/05/2020','00002','Efectivo');
INSERT INTO Factura values('4',200000,'24/05/2020','00001','Efectivo');
INSERT INTO Factura values('5',30000,'24/05/2020','00006','Efectivo');
INSERT INTO Factura values('6',60000,'24/05/2020','00009','Efectivo');
INSERT INTO Factura values('7',250000,'24/05/2020','00001','Tarjeta');
INSERT INTO Factura values('8',87000,'24/05/2020','00005','Tarjeta');
INSERT INTO Factura values('9',43900,'24/05/2020','00002','Tarjeta');
INSERT INTO Factura values('10',150400,'24/05/2020','00008','Tarjeta');
select * from factura;
delete from factura;
 /*Insertamos registros a la tabla DetalleFactura*/
INSERT INTO DetalleFactura values('1',2,20000,'24/05/2020','1','003');
INSERT INTO DetalleFactura values('2',1,40000,'24/05/2020','2','004');
INSERT INTO DetalleFactura values('3',2,20000,'24/05/2020','6','003');
INSERT INTO DetalleFactura values('4',2,70000,'24/05/2020','4','002');
INSERT INTO DetalleFactura values('5',3,30000,'24/05/2020','4','006');
INSERT INTO DetalleFactura values('6',1,30000,'24/05/2020','4','009');
INSERT INTO DetalleFactura values('7',1,30000,'24/05/2020','5','009');
INSERT INTO DetalleFactura values('8',4,200000,'24/05/2020','7','001');
INSERT INTO DetalleFactura values('9',1,40000,'24/05/2020','7','004');
INSERT INTO DetalleFactura values('10',1,10000,'24/05/2020','7','003');
 select * from factura;
 delete from detallefactura;
commit;

CREATE OR REPLACE TRIGGER TG_PRODUCTOS_ACTUALIZAR_STOCK
AFTER INSERT ON DetalleFactura
FOR EACH ROW
DECLARE
BEGIN
     update productos
     set Existencia = Existencia - :new.cantidad
     where Productos_id = :new.Producto_id;

END;
/




select * from productos;

SELECT * FROM DetalleFactura;






























