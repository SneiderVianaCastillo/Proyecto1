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

 SELECT * FROM CLIENTE;
 delete from CLIENTE;
 /*Insertamos registros a la tabla Travjador*/
 INSERT INTO Trabajador values('1','Andres','antonio','Perez','oso','3205421213','vendedor','mayo','valledupar','1','23_45','andre23@gmail.com');

 delete from Trabajador;
 SELECT * FROM cliente;

 /*Insertamos registros a la tabla Proveedor*/
INSERT INTO Proveedor values('1','Mazda','3205421213');

 SELECT * FROM proveedor;

 /*Insertamos registros a la tabla Productos*/
INSERT INTO productos values('001','llantas','llantas para motos de alta velocidad','50000','67000','19','repuesos','2020','1');


 /*Insertamos registros a la tabla Factura*/
INSERT INTO Factura values('1',20000,'24/05/2020','00001','Efectivo');

select * from factura;
delete from factura;
 /*Insertamos registros a la tabla DetalleFactura*/
INSERT INTO DetalleFactura values('2','004'	,'llantas',	'Repuestos'	,'40000',	'1'	,'47600'	,'1');

 select * from factura;
 delete from detallefactura;
commit;

/* DISPARADOR PARA ACTUALIZAR EL STOCK*/

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

/* DISPARADOR PARA CALCULAR EL STOCK*/
CREATE OR REPLACE TRIGGER TG_PRODUCTOS_CALCULAR_STOCK
AFTER INSERT ON productos
DECLARE
BEGIN
     update productos
     set Existencia = Existencia + cantidad
     where Productos_id = Productos_id;

END;
/
/* DISPARADOR PARA CALCULAR EL TOTAL*/

CREATE OR REPLACE TRIGGER TG_TOTAL_PAGAR
AFTER INSERT ON DetalleFactura
FOR EACH ROW
DECLARE
BEGIN
     update factura SET Totales = Totales + :new.Precio_venta * :new.cantidad
     WHERE Factura_id = :NEW.Factura_id;
END;
/


select * from productos;

SELECT * FROM DetalleFactura;

commit;





























