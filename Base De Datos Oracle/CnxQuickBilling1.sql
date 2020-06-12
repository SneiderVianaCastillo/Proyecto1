
CREATE OR REPLACE PACKAGE PKG_INSERTAR AS
PROCEDURE INSERTAR_CLIENTE(Cliente_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Telefono IN varchar,
Email IN VARCHAR2);
END PKG_INSERTAR;
create OR REPLACE PACKAGE BODY PKG_INSERTAR AS
PROCEDURE INSERTAR_CLIENTE(Cliente_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,
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
END INSERTAR_CLIENTE;
END PKG_INSERTAR;

CREATE OR REPLACE PACKAGE PKG_CONSULTAR AS
PROCEDURE CONSULTAR_CLIENTE(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CONSULTAR;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR AS
PROCEDURE CONSULTAR_CLIENTE(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM CLIENTE;
END;
END PKG_CONSULTAR;
commit

SELECT * FROM trabajador;


CREATE OR REPLACE PACKAGE PKG_INSERTAR_TRAB AS
PROCEDURE INSERTAR_TRABAJADOR(Trabajador_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,Telefono IN varchar,
Cargo IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Email IN VARCHAR2);
END PKG_INSERTAR_TRAB;

create OR REPLACE PACKAGE BODY PKG_INSERTAR_TRAB AS
PROCEDURE INSERTAR_TRABAJADOR(Trabajador_id IN varchar2 ,PrimerNombre IN varchar2,SegundoNombre IN varchar2,PrimerApellido IN varchar2,SegundoApellido IN varchar2,
Telefono IN varchar,
Cargo IN varchar2,
Barrio IN varchar2,
Ciudad IN varchar2,
Comuna IN varchar2,
N_Casa IN varchar2,
Email IN VARCHAR2)
AS
BEGIN
INSERT INTO TRABAJADOR VALUES(Trabajador_id,PrimerNombre ,SegundoNombre ,PrimerApellido,SegundoApellido ,Telefono,Cargo,Barrio ,Ciudad ,
Comuna ,N_Casa,Email);
END INSERTAR_TRABAJADOR;
END PKG_INSERTAR_TRAB;

CREATE OR REPLACE PACKAGE PKG_CONSULTAR_TRAB AS
PROCEDURE CONSULTAR_TRABAJADOR(CURSORMEMORIA1 OUT SYS_REFCURSOR);
END PKG_CONSULTAR_TRAB;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR_TRAB AS
PROCEDURE CONSULTAR_TRABAJADOR(CURSORMEMORIA1 OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA1 FOR SELECT *FROM TRABAJADOR;
END;
END PKG_CONSULTAR_TRAB;


CREATE OR REPLACE PACKAGE PKG_INSERTAR_PROV AS
PROCEDURE INSERTAR_PROVEEDOR(Rut IN varchar2 ,Nombre_Comercial IN varchar2,Telefono IN varchar2 );
END PKG_INSERTAR_PROV;
create OR REPLACE PACKAGE BODY PKG_INSERTAR_PROV AS
PROCEDURE INSERTAR_PROVEEDOR(Rut IN varchar2 ,Nombre_Comercial IN varchar2,Telefono IN varchar2)
AS
BEGIN
INSERT INTO PROVEEDOR VALUES(Rut ,Nombre_Comercial,Telefono);
END INSERTAR_PROVEEDOR;
END PKG_INSERTAR_PROV;

CREATE OR REPLACE PACKAGE PKG_CONSULTAR_PROV AS
PROCEDURE CONSULTAR_PROVEEDOR(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CONSULTAR_PROV;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR_PROV AS
PROCEDURE CONSULTAR_PROVEEDOR(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM PROVEEDOR;
END;
END PKG_CONSULTAR_PROV;

CREATE OR REPLACE PACKAGE PKG_INSERTAR_PRODUCTOS AS
PROCEDURE INSERTAR_PRODUCTOS(Productos_id IN varchar2 ,nombre IN varchar2,Descripcion IN varchar2,precio_venta IN number,precio_costo IN number,
Iva IN number,
tipo IN varchar2,
modelo IN varchar2,
cantidad IN int,
Existencia IN int);
END PKG_INSERTAR_PRODUCTOS;

create OR REPLACE PACKAGE BODY PKG_INSERTAR_PRODUCTOS AS
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
END PKG_INSERTAR_PRODUCTOS;


CREATE OR REPLACE PACKAGE PKG_CONSULTAR_PRODUCTOS AS
PROCEDURE CONSULTAR_PRODUCTOS(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CONSULTAR_PRODUCTOS;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR_PRODUCTOS AS
PROCEDURE CONSULTAR_PRODUCTOS(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM PRODUCTOS;
END;
END PKG_CONSULTAR_PRODUCTOS;
commit




CREATE OR REPLACE PACKAGE PKG_INSERTAR_FACTURA AS
PROCEDURE INSERTAR_FACTURA(Factura_id IN varchar2 ,Totales IN number,Fecha IN Date,Cliente_id IN Varchar2,FormaDePago IN Varchar2);
END PKG_INSERTAR_FACTURA;

create OR REPLACE PACKAGE BODY PKG_INSERTAR_FACTURA AS
PROCEDURE INSERTAR_FACTURA(Factura_id IN varchar2 ,Totales IN number,Fecha IN Date,Cliente_id IN Varchar2,FormaDePago IN Varchar2)
AS
BEGIN
INSERT INTO FACTURA VALUES(Factura_id ,Totales ,Fecha,Cliente_id,FormaDePago );
END INSERTAR_FACTURA;
END PKG_INSERTAR_FACTURA;


CREATE OR REPLACE PACKAGE PKG_CONSULTAR_FACTURA AS
PROCEDURE CONSULTAR_FACTURA(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CONSULTAR_FACTURA;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR_FACTURA AS
PROCEDURE CONSULTAR_FACTURA(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM FACTURA;
END;
END PKG_CONSULTAR_FACTURA;
commit


CREATE OR REPLACE PACKAGE PKG_INSERTAR_DETALLEFACTURA AS
PROCEDURE INSERTAR_DETALLEFACTURA(DetalleFac_id IN varchar2,Cantidad IN int ,Costo IN number,Factura_id IN Varchar2,Producto_id IN Varchar2);
END PKG_INSERTAR_DETALLEFACTURA;

create OR REPLACE PACKAGE BODY PKG_INSERTAR_DETALLEFACTURA AS
PROCEDURE INSERTAR_DETALLEFACTURA(DetalleFac_id IN varchar2,Cantidad IN int ,Costo IN number,Factura_id IN Varchar2,Producto_id IN Varchar2)
AS
BEGIN
INSERT INTO DETALLEFACTURA VALUES(DetalleFac_id ,Cantidad ,Costo,Factura_id ,Producto_id  );
END INSERTAR_DETALLEFACTURA;
END PKG_INSERTAR_DETALLEFACTURA;

CREATE OR REPLACE PACKAGE PKG_CONSULTAR_DETALLEFACTURA AS
PROCEDURE CONSULTAR_DETALLEFACTURA(CURSORMEMORIA OUT SYS_REFCURSOR);
END PKG_CONSULTAR_DETALLEFACTURA;
CREATE OR REPLACE PACKAGE BODY PKG_CONSULTAR_DETALLEFACTURA AS
PROCEDURE CONSULTAR_DETALLEFACTURA(CURSORMEMORIA OUT SYS_REFCURSOR) AS
BEGIN
OPEN CURSORMEMORIA FOR SELECT *FROM FACTURA;
END;
END PKG_CONSULTAR_DETALLEFACTURA;
commit



