create database Pintucor


create table provincia(
id_provincia int identity,
nombre varchar(20),
constraint pk_id primary key (id_provincia)
)

create table localidad(
id_localidad int identity,
nombre varchar(20),
id_provincia int,
constraint pk_id_l primary key(id_localidad),
constraint fk_id_p foreign key(id_provincia) references provincia(id_provincia)
)

create table barrio(
id_barrio int identity,
nombre varchar(20),
id_localidad int,
constraint pk_id_b primary key (id_barrio),
constraint fk_id_l foreign key(id_localidad) references localidad(id_localidad)
)

create table cliente(
id_cliente int identity,
nombre varchar(20),
apellido varchar(20),
direccion varchar(20),
telefono numeric(10),
dni int,
email varchar(10),
id_barrio int,
constraint pk_id_cliente primary key(id_cliente),
constraint fk_id_b foreign key(id_barrio) references barrio (id_barrio)
)

create table estado(
id_estado int identity,
 descripcion varchar(20),
 constraint pk_id_estado primary key (id_estado)
)

create table envio(
id_envio int identity,
id_estado int,
direccion varchar(20),
id_cliente int,
codigo_producto int,
constraint pk_id_envio primary key(id_envio),
constraint fk_id_estado foreign key(id_estado) references estado(id_estado),
constraint fk_id_cliente foreign key(id_cliente) references cliente(id_cliente),
constraint fk_codigo_producto foreign key(codigo_producto) references producto (codigo)
)

create table forma_pago(
id_forma_pago int identity,
descripcion varchar(20),
constraint id_forma_pago primary key (id_forma_pago)
)

create table seccion(
id_seccion int identity,
descripcion varchar(20),
constraint pk_id_s primary key (id_seccion)
)

create table estante(
id_estante int identity,
descripcion varchar(20),
id_seccion int,
constraint pk_id_e primary key (id_estante),
constraint fk_id_s foreign key(id_seccion) references seccion(id_seccion)
)

create table sector(
id_sector int identity,
descripcion varchar(20),
id_estante int,
constraint pk_id_sector primary key (id_sector),
constraint fk_id_e foreign key(id_estante)references estante(id_estante)

)

create table tipo_pintura(
id_tipo int identity,
titulo varchar(40),
tipoPintura varchar(50)
constraint pk_id_tipo primary key (id_tipo)
)

create table producto(
codigo int identity,
tipo_producto varchar(20),
descripcion varchar(80),
id_tipo_pintura int null,
id_marca int,
id_color int,
acabado varchar(50), --BRILLANTE, EXTRA BRILLANTE, MATE, METALIZADA, SATINADO, SEMI BRILLO, SEMI MATE, TORNASOLADO
tamaño int,
precio float,
id_sector int,
constraint pk_cod_p primary key(codigo),
constraint fk_s foreign key (id_sector) references sector(id_sector),
constraint fk_id_t foreign key(id_tipo_pintura) references tipo_pintura(id_tipo),
constraint fk_marca foreign key(id_marca) references marca(id_marca),
constraint fk_color foreign key(id_color) references color(id_color)
)


create table color(
id_color int identity,
descripcion varchar(30),
constraint pk_color primary key (id_color)
)

create table marca(
id_marca int identity,
descripcion varchar(30),
constraint pk_marca primary key(id_marca)
)

create table empleado(
id_empleado int identity,
apellido varchar(30),
nombre varchar(30),
dni int,
cargo varchar(30),
id_usuario int,
constraint pk_id_empleado primary key (id_empleado),
constraint fk_usuario foreign key(id_usuario) references usuario(id_usuario)
)


create table usuario(
id_usuario int identity,
email varchar(100) not null,
password varchar(256) not null,
nombre varchar(50) not null,
constraint pk_usuario primary key (id_usuario)
)



create table venta(
nroFac int identity,
id_cliente int,
id_forma_pago int,
fecha_venta date,
id_empleado int,
id_envio int,
constraint pk_nroFac primary key (nroFac),
constraint fk_id_c foreign key(id_cliente) references cliente(id_cliente),
constraint fk_id_forma_pago foreign key(id_forma_pago) references forma_pago(id_forma_pago),
constraint fk_id_empleado foreign key(id_empleado) references empleado (id_empleado),
constraint fk_id_env foreign key(id_envio) references envio(id_envio)
)


create table detalle_venta(
nroFac int,
codigo_producto int,
cantidad int,
descripcion varchar(80),
precio_unitario float,
importe_bruto float,
descuento float,
impuesto float,
total float,
constraint fk_nroF foreign key(nroFac) references venta(nroFac),
constraint fk_cod foreign key(codigo_producto) references producto(codigo)
)


--INSERTS ESTADOS
insert into estado (descripcion) values ('En el local')
insert into estado (descripcion) values ('En camino')
insert into estado (descripcion) values ('Cancelado')
insert into estado (descripcion) values ('Entregado')

--INSERTS PROVINCIA
insert into provincia (nombre) values ('Buenos Aires')
insert into provincia (nombre) values ('CABA')
insert into provincia (nombre) values ('Catamarca')
insert into provincia (nombre) values ('Chaco')
insert into provincia (nombre) values ('Chubut')
insert into provincia (nombre) values ('Córdoba')
insert into provincia (nombre) values ('Corrientes')
insert into provincia (nombre) values ('Entre Ríos')
insert into provincia (nombre) values ('Formosa')
insert into provincia (nombre) values ('Jujuy')
insert into provincia (nombre) values ('La Pampa')
insert into provincia (nombre) values ('La Rioja')
insert into provincia (nombre) values ('Mendoza')
insert into provincia (nombre) values ('Misiones')
insert into provincia (nombre) values ('Neuquén')
insert into provincia (nombre) values ('Río Negro')
insert into provincia (nombre) values ('Salta')
insert into provincia (nombre) values ('San Juan')
insert into provincia (nombre) values ('San Luis')
insert into provincia (nombre) values ('Santa Cruz')
insert into provincia (nombre) values ('Santa Fe')
insert into provincia (nombre) values ('Santiago del Estero')
insert into provincia (nombre) values ('Tierra del Fuego')
insert into provincia (nombre) values ('Tucumán')

--INSERTS SECCION
insert into seccion (descripcion) values ('Fila 1')
insert into seccion (descripcion) values ('Fila 2')
insert into seccion (descripcion) values ('Fila 3')
insert into seccion (descripcion) values ('Fila 4')

--INSERTS ESTANTES
insert into estante(descripcion,id_seccion) values ('Estante 1', 1)
insert into estante(descripcion,id_seccion) values ('Estante 1', 2)
insert into estante(descripcion,id_seccion) values ('Estante 1', 3)
insert into estante(descripcion,id_seccion) values ('Estante 1', 4)
insert into estante(descripcion,id_seccion) values ('Estante 2', 1)
insert into estante(descripcion,id_seccion) values ('Estante 2', 2)
insert into estante(descripcion,id_seccion) values ('Estante 2', 3)
insert into estante(descripcion,id_seccion) values ('Estante 2', 4)

--INSERTS SECTOR
insert into sector (descripcion, id_estante) values ('A', 1)
insert into sector (descripcion, id_estante) values ('A', 2)
insert into sector (descripcion, id_estante) values ('A', 3)
insert into sector (descripcion, id_estante) values ('A', 4)
insert into sector (descripcion, id_estante) values ('B', 5)
insert into sector (descripcion, id_estante) values ('B', 6)
insert into sector (descripcion, id_estante) values ('B', 7)
insert into sector (descripcion, id_estante) values ('B', 8)

--INSERTS TIPO PINTURA
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Fibrado')
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Frentes y muros')
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Ladrillo visto')
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Asfáltica')
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Membrana Líquida')
insert into tipo_pintura(titulo, tipoPintura) values ('Impermeable', 'Membrana poliuretanica')
insert into tipo_pintura(titulo, tipoPintura) values ('Protector', 'Barniz')
insert into tipo_pintura(titulo, tipoPintura) values ('Protector', 'Laca')
insert into tipo_pintura(titulo, tipoPintura) values ('Protector', 'Protector impregnante')
insert into tipo_pintura(titulo, tipoPintura) values ('Revestimiento de Pared', 'Texturado con llana')
insert into tipo_pintura(titulo, tipoPintura) values ('Revestimiento de Pared', 'Texturado con rodillo')
insert into tipo_pintura(titulo, tipoPintura) values ('Revestimiento de Pared', 'Efectos especiales')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Decorativo')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Automotor')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Lubricante')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Altas temperaturas')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Antideslizante')
insert into tipo_pintura(titulo, tipoPintura) values ('Aerosol', 'Epoxy')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Alta temperatura')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Ligante')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Azulejos y cerámicos')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Melamina, vidrio o plástico')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Paredes húmedas/Antisalitre')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Problemas de humedad')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Epoxy hogar y obra')
insert into tipo_pintura(titulo, tipoPintura) values ('Producto Especial', 'Tizada')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Esmalte base agua')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Esmalte base solvente')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Microcemento')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Demarcación vial')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Plastificante')
insert into tipo_pintura(titulo, tipoPintura) values ('Pisos', 'Sellador piso de madera')
insert into tipo_pintura(titulo, tipoPintura) values ('Piletas', 'Caucho clorado')
insert into tipo_pintura(titulo, tipoPintura) values ('Piletas', 'Latex/Acrilica')
insert into tipo_pintura(titulo, tipoPintura) values ('Piletas', 'Solvente')
insert into tipo_pintura(titulo, tipoPintura) values ('Latex', 'Interiores')
insert into tipo_pintura(titulo, tipoPintura) values ('Latex', 'Exteriores')
insert into tipo_pintura(titulo, tipoPintura) values ('Latex', 'Interior/Exterior')
insert into tipo_pintura(titulo, tipoPintura) values ('Latex', 'Cielorraso')
insert into tipo_pintura(titulo, tipoPintura) values ('Sinteticos', 'Esmalte base agua')
insert into tipo_pintura(titulo, tipoPintura) values ('Sinteticos', 'Esmalte base solvente')


--INSERTS FORMA PAGO
insert into forma_pago (descripcion) values('Efectivo')
insert into forma_pago (descripcion) values('Tarjeta Debito')
insert into forma_pago (descripcion) values('Tarjeta Credito')


--INSERTS EMPLEADO
insert into empleado(apellido, nombre, dni, cargo) values ('Ramirez', 'Ramiro', 34345890, 'Admin')
insert into empleado(apellido, nombre, dni, cargo) values ('Fernandez', 'Fernando', 32555090, 'Empleado Caja')
insert into empleado(apellido, nombre, dni, cargo) values ('Gonzalez', 'Gonzalo', 30993453, 'Empleado Stock')


insert into usuario (email,password, nombre) values ('admin@mail.com', 'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb', 'ADMIN')





