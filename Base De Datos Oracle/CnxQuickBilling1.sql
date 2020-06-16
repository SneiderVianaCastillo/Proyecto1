
CREATE OR REPLACE PACKAGE PKG_CLIENTE AS
PROCEDURE SP_INSERTAR_CLIENTE(Cliente_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Telefono IN varchar,
Email IN VARCHAR2);
PROCEDURE SP_ELIMINAR_CLIENTE(Identificacion varchar2);
PROCEDURE SP_MODIFICAR_CLIENTE(xCliente_id varchar2 ,XPrimerNombre  varchar2,xSegundoNombre varchar2,xPrimerApellido  varchar2,xSegundoApellido varchar2,
xBarrio  varchar2,
xCiudad varchar2,
xComuna  varchar2,
xN_Casa  varchar2,
xTelefono  varchar,
xEmail VARCHAR2);
PROCEDURE SP_CONSULTAR_CLIENTE(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CLIENTE;

CREATE OR REPLACE PACKAGE BODY PKG_CLIENTE 
AS
PROCEDURE SP_INSERTAR_CLIENTE(Cliente_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Telefono IN varchar,
Email IN VARCHAR2)
AS
BEGIN
INSERT INTO CLIENTE VALUES(Cliente_id  ,PrimerNombre ,SegundoNombre ,PrimerApellido,SegundoApellido ,Barrio ,Ciudad ,
Comuna ,N_Casa,Telefono,Email);
END SP_INSERTAR_CLIENTE;

PROCEDURE SP_MODIFICAR_CLIENTE(xCliente_id varchar2 ,XPrimerNombre  varchar2,xSegundoNombre varchar2,xPrimerApellido  varchar2,xSegundoApellido varchar2,
xBarrio  varchar2,
xCiudad varchar2,
xComuna  varchar2,
xN_Casa  varchar2,
xTelefono  varchar,
xEmail VARCHAR2)
AS
BEGIN
UPDATE CLIENTE
SET PrimerNombre= xPrimerNombre,SegundoNombre= xSegundoNombre,PrimerApellido= xPrimerApellido,SegundoApellido= xSegundoApellido,
Barrio= xBarrio,Ciudad= xCiudad,Comuna= xComuna ,N_Casa= xN_Casa ,Telefono=xTelefono ,Email= xEmail
WHERE Cliente_id=xCliente_id;
END SP_MODIFICAR_CLIENTE;

PROCEDURE SP_ELIMINAR_CLIENTE(Identificacion varchar2)
AS
BEGIN
DELETE FROM CLIENTE where Cliente_id = Identificacion;
END SP_ELIMINAR_CLIENTE;

PROCEDURE SP_CONSULTAR_CLIENTE(CURSORMEMORIA OUT SYS_REFCURSOR) 
AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM CLIENTE;
END;

END PKG_CLIENTE;

COMMIT;





CREATE OR REPLACE PACKAGE PKG_TRABAJADOR AS
PROCEDURE SP_INSERTAR_TRABAJADOR(Trabajador_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,Telefono IN varchar,
Cargo IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Email IN VARCHAR2);
PROCEDURE SP_ELIMINAR_TRABAJADOR(Identificacion varchar2);
PROCEDURE SP_MODIFICAR_TRABAJADOR(xTrabajador_id varchar2 ,XPrimerNombre  varchar2,xSegundoNombre varchar2,xPrimerApellido  varchar2,xSegundoApellido varchar2,
xBarrio  varchar2,
xCiudad varchar2,
xComuna  varchar2,
xN_Casa  varchar2,
xTelefono  varchar,
xCargo varchar2,
xEmail VARCHAR2);
PROCEDURE SP_CONSULTAR_TRABAJADOR(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_TRABAJADOR;

CREATE OR REPLACE PACKAGE BODY PKG_TRABAJADOR 
AS
PROCEDURE SP_INSERTAR_TRABAJADOR(Trabajador_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,Telefono IN varchar,
Cargo IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Email IN VARCHAR2)
AS
BEGIN
INSERT INTO TRABAJADOR  VALUES(Trabajador_id,PrimerNombre ,SegundoNombre ,PrimerApellido,SegundoApellido ,Telefono,Cargo,Barrio ,Ciudad ,
Comuna ,N_Casa,Email);
END SP_INSERTAR_TRABAJADOR;

PROCEDURE SP_MODIFICAR_TRABAJADOR (xTrabajador_id varchar2 ,XPrimerNombre  varchar2,xSegundoNombre varchar2,xPrimerApellido  varchar2,xSegundoApellido varchar2,
xBarrio  varchar2,
xCiudad varchar2,
xComuna  varchar2,
xN_Casa  varchar2,
xTelefono  varchar,
xCargo varchar2,
xEmail VARCHAR2)
AS
BEGIN
UPDATE TRABAJADOR
SET PrimerNombre= xPrimerNombre,SegundoNombre= xSegundoNombre,PrimerApellido= xPrimerApellido,SegundoApellido= xSegundoApellido,
Barrio= xBarrio,Ciudad= xCiudad,Comuna= xComuna ,N_Casa= xN_Casa ,Telefono=xTelefono,Cargo=xCargo ,Email= xEmail
WHERE Trabajador_id=xTrabajador_id;
END SP_MODIFICAR_TRABAJADOR;

PROCEDURE SP_ELIMINAR_TRABAJADOR(Identificacion varchar2)
AS
BEGIN
DELETE FROM TRABAJADOR where Trabajador_id = Identificacion;
END SP_ELIMINAR_TRABAJADOR;

PROCEDURE SP_CONSULTAR_TRABAJADOR(CURSORMEMORIA OUT SYS_REFCURSOR) 
AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM TRABAJADOR;
END;

END PKG_TRABAJADOR;

commit;





CREATE OR REPLACE PACKAGE PKG_PROVEEDOR AS
PROCEDURE SP_INSERTAR_PROVEEDOR(Rut IN varchar2 ,Nombre_Comercial IN varchar2,Telefono IN varchar2 );
PROCEDURE SP_ELIMINAR_PROVEEDOR(Rut varchar2);
PROCEDURE c(xRut varchar2 ,xNombre_Comercial varchar2,xTelefono  varchar2 );
PROCEDURE SP_CONSULTAR_PROVEEDOR(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_PROVEEDOR;

CREATE OR REPLACE PACKAGE BODY PKG_PROVEEDOR 
AS
PROCEDURE SP_INSERTAR_PROVEEDOR (Rut IN varchar2 ,Nombre_Comercial IN varchar2,Telefono IN varchar2)
AS
BEGIN
INSERT INTO PROVEEDOR VALUES(Rut ,Nombre_Comercial,Telefono);
END SP_INSERTAR_PROVEEDOR;

PROCEDURE SP_MODIFICAR_PROVEEDOR(xRut varchar2 ,xNombre_Comercial varchar2,xTelefono varchar2)
AS
BEGIN
UPDATE PROVEEDOR
SET Rut=xRut ,Nombre_Comercial=xNombre_Comercial,Telefono=xTelefono 
WHERE Rut=xRut;
END SP_MODIFICAR_PROVEEDOR;

PROCEDURE SP_ELIMINAR_PROVEEDOR(Rut varchar2)
AS
BEGIN
DELETE FROM PROVEEDOR where Rut = Rut;
END SP_ELIMINAR_PROVEEDOR;

PROCEDURE SP_CONSULTAR_PROVEEDOR(CURSORMEMORIA OUT SYS_REFCURSOR) 
AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM PROVEEDOR;
END;

END PKG_PROVEEDOR;

commit;


CREATE OR REPLACE PACKAGE PKG_PRODUCTOS AS
PROCEDURE INSERTAR_PRODUCTOS(Productos_id IN varchar2 ,nombre IN varchar2,Descripcion IN varchar2,precio_venta IN number,precio_costo IN number,
Iva IN number,
tipo IN varchar2,
modelo IN varchar2,
cantidad IN int,
Existencia IN int);
PROCEDURE SP_ELIMINAR_PRODUCTOS(xProductos_id varchar2);
PROCEDURE SP_MODIFICAR_PRODUCTOS(xProductos_id  varchar2 ,xnombre varchar2,xDescripcion  varchar2,xprecio_venta  number,xprecio_costo number,
xIva  number,
xtipo  varchar2,
xmodelo  varchar2,
xcantidad  int,
xExistencia  int);
PROCEDURE SP_CONSULTAR_PRODUCTOS(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_PRODUCTOS;

CREATE OR REPLACE PACKAGE BODY PKG_PRODUCTOS AS
PROCEDURE INSERTAR_PRODUCTOS(Productos_id IN varchar2 ,nombre IN varchar2,Descripcion IN varchar2,precio_venta IN number,precio_costo IN number,
Iva IN number,
tipo IN varchar2,
modelo IN varchar2,
cantidad IN int,
Existencia IN int)
AS
BEGIN
INSERT INTO PRODUCTOS VALUES(Productos_id ,nombre,Descripcion ,precio_venta ,precio_costo,Iva ,tipo,modelo,cantidad,Existencia);
END INSERTAR_PRODUCTOS;

PROCEDURE SP_MODIFICAR_PRODUCTOS (xProductos_id  varchar2 ,xnombre varchar2,xDescripcion  varchar2,xprecio_venta  number,xprecio_costo number,
xIva  number,
xtipo  varchar2,
xmodelo  varchar2,
xcantidad  int,
xExistencia  int)
AS
BEGIN
UPDATE PRODUCTOS
SET Productos_id = xProductos_id,Nombre=xnombre,Descripcion= xDescripcion,Precio_venta =xprecio_venta,Precio_costo=xprecio_costo,Iva=xIva ,Tipo=xtipo,Modelo=xmodelo,Cantidad=xcantidad,Existencia=xExistencia
WHERE Productos_id= xProductos_id;
END SP_MODIFICAR_PRODUCTOS;

PROCEDURE SP_CONSULTAR_PRODUCTOS(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM PRODUCTOS;
END;

PROCEDURE SP_ELIMINAR_PRODUCTOS(xProductos_id varchar2)
AS
BEGIN
DELETE FROM PRODUCTOS where PRODUCTOS_ID = xProductos_id;
END SP_ELIMINAR_PRODUCTOS;

END PKG_PRODUCTOS;

commit;

CREATE OR REPLACE PACKAGE PKG_FACTURA AS
PROCEDURE SP_INSERTAR_FACTURA(Factura_id IN varchar2 ,Totales IN number,Fecha IN Date,Cliente_id IN Varchar2,FormaDePago IN Varchar2);
PROCEDURE SP_ELIMINAR_FACTURA(XFactura_id varchar2);
PROCEDURE SP_MODIFICAR_FACTURA(xFactura_id varchar2 ,xTotales number,xFecha Date,xCliente_id  Varchar2,xFormaDePago  Varchar2);
PROCEDURE CONSULTAR_FACTURA(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_FACTURA;

create OR REPLACE PACKAGE BODY PKG_FACTURA AS
PROCEDURE SP_INSERTAR_FACTURA(Factura_id IN varchar2 ,Totales IN number,Fecha IN Date,Cliente_id IN Varchar2,FormaDePago IN Varchar2)
AS
BEGIN
INSERT INTO FACTURA VALUES(Factura_id ,Totales ,Fecha,Cliente_id,FormaDePago );
END SP_INSERTAR_FACTURA;

PROCEDURE SP_ELIMINAR_FACTURA(XFactura_id varchar2)
AS
BEGIN
DELETE FROM FACTURA where Factura_id = XFactura_id;
END SP_ELIMINAR_FACTURA;

PROCEDURE SP_MODIFICAR_FACTURA(xFactura_id varchar2 ,xTotales number,xFecha Date,xCliente_id  Varchar2,xFormaDePago  Varchar2)
AS
BEGIN
UPDATE FACTURA
SET Factura_id = xFactura_id,Totales=xTotales,Fecha= xFecha,Cliente_id =xCliente_id,FormaDePago=xFormaDePago
WHERE Factura_id= xFactura_id;
END SP_MODIFICAR_FACTURA;

PROCEDURE CONSULTAR_FACTURA(CURSORMEMORIA OUT SYS_REFCURSOR) as
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM FACTURA;
END;

END PKG_FACTURA;


commit;


CREATE OR REPLACE PACKAGE PKG_DETALLEFACTURA AS
PROCEDURE SP_INSERTAR_DETALLEFACTURA(DetalleFac_id IN varchar2,
Producto_id IN Varchar2,Nombre IN Varchar2,
Tipo IN Varchar2,Precio_venta IN Varchar2,Cantidad IN int ,
Total IN number,Factura_id IN Varchar2);
PROCEDURE SP_CONSULTAR_DETALLEFACTURA(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_DETALLEFACTURA;
create OR REPLACE PACKAGE BODY PKG_DETALLEFACTURA AS
PROCEDURE SP_INSERTAR_DETALLEFACTURA(DetalleFac_id IN varchar2,Producto_id IN Varchar2,Nombre IN Varchar2,Tipo IN Varchar2,Precio_venta IN Varchar2,Cantidad IN int ,Total IN number,Factura_id IN Varchar2)
AS
BEGIN
INSERT INTO DETALLEFACTURA VALUES(DetalleFac_id ,Producto_id,Nombre,Tipo,Precio_venta,Cantidad ,Total ,Factura_id );
END SP_INSERTAR_DETALLEFACTURA;

PROCEDURE SP_CONSULTAR_DETALLEFACTURA(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM DETALLEFACTURA;
END;

END PKG_DETALLEFACTURA;

/*4902800*/
commit;
select *from factura;

drop package PKG_INSERTAR_PROV;