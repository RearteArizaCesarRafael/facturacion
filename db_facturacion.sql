create database db_loderafa
use db_loderafa
--TABLA ARTICULOS--
create table T_ARTICULOS(
id_articulo int identity(1,1) not null,
nombre_a varchar(255) not null,
precio_unitario numeric (8,2)not null,
constraint pk_id_articulo primary key (id_articulo),
)
--INSERT ARTICULOS--
SET IDENTITY_INSERT T_ARTICULOS ON
insert T_ARTICULOS (id_articulo,nombre_a,precio_unitario) VALUES (1,'Fernet Branca 750ml',3000)
select * from T_ARTICULOS
SET IDENTITY_INSERT T_ARTICULOS OFF


--TABLA FORMA PAGO--
create table T_FORMA_PAGO(
id_forma_pago int not null,
metodo_pago varchar(255) not null,
constraint pk_id_forma_pago primary key (id_forma_pago)
)
--INSERT FORMA PAGO--
insert T_FORMA_PAGO (id_forma_pago,metodo_pago) values (1,'Efectivo')
insert T_FORMA_PAGO (id_forma_pago,metodo_pago) values (2,'Transferencia')
insert T_FORMA_PAGO (id_forma_pago,metodo_pago) values (3,'Debito')
insert T_FORMA_PAGO (id_forma_pago,metodo_pago) values (4,'Credito')
select * from T_FORMA_PAGO


--TABLA CLIENTE--
create table T_CLIENTE(
id_cliente int identity(1,1) not null,
nombre_c varchar(255)not null,
apellido_c varchar(255)not null,
mail_c varchar(255)null,
direccion_c varchar(255)null,
constraint pk_id_cliente primary key (id_cliente)
)
--INSERT CLIENTE--
set identity_insert T_CLIENTE on
INSERT T_CLIENTE (id_cliente,nombre_c,apellido_c,mail_c,direccion_c) VALUES (1,'Rafael','Rearte','rafirearte@gmail.com','27 de abril')
set identity_insert T_CLIENTE off
select * from T_CLIENTE


--TABLA FACTURA--
create table T_FACTURA(
id_factura int identity(1,1)not null,
fecha date not null,
id_forma_pago int not null,
id_cliente int null,
descuento numeric(5, 2) NULL,
total numeric(8, 2) NOT NULL,
constraint pk_id_factura primary key (id_factura),
constraint fk_id_forma_pago foreign key (id_forma_pago)
references T_FORMA_PAGO (id_forma_pago),
constraint fk_id_cliente foreign key (id_cliente)
references T_CLIENTE (id_cliente),
)
--INSERT FACTURA--
set dateformat dmy
set identity_insert T_FACTURA on
INSERT T_FACTURA (id_factura, fecha, id_forma_pago, id_cliente, descuento, total) VALUES (1, '11/01/2023', 2,1,0,3000)
set identity_insert T_FACTURA off
select * from T_FACTURA


--TABLA DETALLE FACTURA--
create table T_DETALLE_FACTURA(
id_detalle_factura int identity(1,1)not null,
id_factura int not null,
id_articulo int not null,
cantidad int null,
precio numeric (8,2)not null,
constraint pk_id_detalle_factura primary key (id_detalle_factura),
constraint fk_id_factura foreign key (id_factura)
references T_FACTURA (id_factura),
constraint fk_id_articulo foreign key (id_articulo)
references T_ARTICULOS (id_articulo),
)
--INSERT DETALLE FACTURA--

set identity_insert T_DETALLE_FACTURA on
INSERT T_DETALLE_FACTURA (id_detalle_factura,id_factura,id_articulo,cantidad,precio) VALUES (1,1,1,1,3000)
set identity_insert T_DETALLE_FACTURA off
select * from T_DETALLE_FACTURA


--STORED PROCEDURE--

--SP ARTICULOS--
CREATE PROCEDURE SP_CONSULTAR_ARTICULOS
AS
BEGIN
	
	SELECT * from T_ARTICULOS;
END
-- SP CLIENTE--
CREATE PROCEDURE SP_CLIENTE
AS
BEGIN
	
	SELECT * from T_CLIENTE;
END
-- SP FACTURA--
CREATE PROCEDURE SP_CONSULTAR_FACTURA
AS
BEGIN
	
	SELECT * from T_FACTURA;
END
--SP FORMA PAGO--
CREATE PROCEDURE SP_CONSULTAR_FORMA_PAGO
AS
BEGIN
	
	SELECT * from T_FORMA_PAGO;
END

--SP PROXIMO ID
CREATE PROCEDURE SP_PROXIMO_ID
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_factura)+1  FROM T_FACTURA);
END



--CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
--	@cliente varchar(255), 
--	@dto numeric(5,2),
--	@total numeric(8,2),
--	@presupuesto_nro int OUTPUT
--AS
--BEGIN
--	INSERT INTO T_PRESUPUESTOS(fecha, cliente, descuento, total)
--    VALUES (GETDATE(), @cliente, @dto, @total);
--    --Asignamos el valor del último ID autogenerado (obtenido --  
--    --mediante la función SCOPE_IDENTITY() de SQLServer)	
--    SET @presupuesto_nro = SCOPE_IDENTITY();

--END
--GO



--CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
--	@presupuesto_nro int,
--	@detalle int, 
--	@id_producto int, 
--	@cantidad int
--AS
--BEGIN
--	INSERT INTO T_DETALLES_PRESUPUESTO(presupuesto_nro,detalle_nro, id_producto, cantidad)
--    VALUES (@presupuesto_nro, @detalle, @id_producto, @cantidad);
  
--END
--GO
