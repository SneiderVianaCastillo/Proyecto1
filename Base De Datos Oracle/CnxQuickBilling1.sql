
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



commit


SELECT *FROM Cliente;