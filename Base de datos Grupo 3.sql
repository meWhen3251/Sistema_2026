--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- Tablas de gestión de usuario usadas
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

CREATE TABLE Personas(
    ID_Persona int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Legajo int UNIQUE NOT NULL,
    DNI int NOT NULL,
    Nombre nchar(40) NOT NULL,
    Apellido nchar(40) NOT NULL,
    Correo nchar(50) NOT NULL
);

CREATE TABLE Usuarios(
    ID_Usuario int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nombre nvarchar(50) NOT NULL,
    ID_Persona int NOT NULL,
    ID_Clave int NOT NULL,
    CONSTRAINT FK_Usuarios_Personas FOREIGN KEY(ID_Persona)
    REFERENCES Personas(ID_Persona)
);

--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--
-- Partes pertenecientes a gestión de ventas
--♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥--

/*
                        [Categorias]

           La tabla se integra para poder utilizar  
                        (Productos),
   la cual permite el uso de (Solicitudes_Compra_Interna)
*/
CREATE TABLE Categorias(
    ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nombre VARCHAR NOT NULL,
    Descripcion VARCHAR NOT NULL
);

/*
                          [Marcas]

           La tabla se integra para poder utilizar  
                        (Productos),
   la cual permite el uso de (Solicitudes_Compra_Interna)
*/
CREATE TABLE Marcas(
    ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nombre_marca VARCHAR NOT NULL
);

/*
                            [Productos]

   Pertenenciente a grupo 1, la tabla se integra para poder utilizar  
                     (Solicitudes_Compra_Interna)
*/
CREATE TABLE Productos(
    ID_Codigo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Categoria INT NOT NULL,
    FK_Marca INT NOT NULL,
    Nombre VARCHAR NOT NULL,
    Precio_Compra INT NOT NULL,
    Precio_Venta INT NOT NULL,
    Stock_Actual INT NOT NULL,
    Stock_Minimo INT NOT NULL,
    Stock_Critico INT NOT NULL,
    Stock_Ideal INT NOT NULL,
    Stock_Maximo INT NOT NULL,
    Punto_Reposicion INT NOT NULL,
    Numero_Lote INT NOT NULL,
    Fecha_Vencimiento datetime NOT NULL,
    Estado VARCHAR NOT NULL,
    Habilitado bit NOT NULL
    
    CONSTRAINT FK_Productos_Categoria FOREIGN KEY(FK_Categoria)
    REFERENCES Categorias(ID),

    CONSTRAINT FK_Productos_Marca FOREIGN KEY(FK_Marca)
    REFERENCES Marcas(ID)


);


/*
                            [Proveedores]

   Pertenenciente a grupo 2, la tabla se integra para poder utilizar  
                        (Presupuestos_Compra)
*/

CREATE TABLE Proveedores(
    ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Razon_Social VARCHAR NOT NULL,
    CUIT INT NOT NULL,
    Email VARCHAR NOT NULL,
    Direccion VARCHAR NOT NULL,
    Descuento_General INT NOT NULL,
    Activo bit NOT NULL
);

/*
♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥
Partes del Grupo 3 base, Presupuestos y Órdenes de compra
              Es decir, nuestro grupo.
♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ☻ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥
*/

CREATE TABLE Solicitudes_Compra_Interna(
    ID INT  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Producto INT NOT NULL,
    FK_Usuario INT NOT NULL,
    Fecha_Emision datetime NOT NULL,
    Cantidad_Solicitada INT NOT NULL,
    Estado VARCHAR NOT NULL,

    CONSTRAINT FK_Solicitudes_Compra_Interna_Producto FOREIGN KEY(FK_Producto)
    REFERENCES Productos(ID_Codigo),

    CONSTRAINT FK_Solicitudes_Compra_Interna_Usuario FOREIGN KEY(FK_Usuario)
    REFERENCES Usuarios(ID_Usuario)

);

CREATE TABLE Presupuestos_Compra(
    ID INT  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Solicitud_Compra_Interna INT NOT NULL,
    FK_Proveedor INT NOT NULL,
    FK_Usuario INT NOT NULL,
    Fecha_Emision datetime NOT NULL,
    Estado VARCHAR NOT NULL,

    CONSTRAINT FK_Presupuestos_Compra_Solicitud_Compra_Interna FOREIGN KEY(FK_Solicitud_Compra_Interna)
    REFERENCES Solicitudes_Compra_Interna(ID),
    
    CONSTRAINT FK_Presupuestos_Compra_Proveedor FOREIGN KEY(FK_Proveedor)
    REFERENCES Proveedores(ID),

    CONSTRAINT FK_Presupuestos_Compra_Usuario FOREIGN KEY(FK_Usuario)
    REFERENCES Usuarios(ID_Usuario)

);

CREATE TABLE Detalle_Presupuestos_Compra(
    ID INT  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Presupuesto_Compra INT NOT NULL,
    FK_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario INT NOT NULL,

    CONSTRAINT FK_Detalle_Presupuestos_Compra_Presupuesto_Compra FOREIGN KEY(FK_Presupuesto_Compra)
    REFERENCES Presupuestos_Compra(ID),
    
    CONSTRAINT FK_Detalle_Compra_Interna_Producto FOREIGN KEY(FK_Producto)
    REFERENCES Productos(ID_Codigo),
);

CREATE TABLE Ordenes_Compra(
    ID INT  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Proveedor INT NOT NULL,
    FK_Presupuesto_Compra INT NOT NULL,
    FK_Usuario INT NOT NULL,
    Fecha_Emision datetime NOT NULL,
    Estado VARCHAR NOT NULL,

    CONSTRAINT FK_Ordenes_Compra_Proveedor FOREIGN KEY(FK_Proveedor)
    REFERENCES Proveedores(ID),

    CONSTRAINT FK_Ordenes_Compra_Presupuesto_Compra FOREIGN KEY(FK_Presupuesto_Compra)
    REFERENCES Presupuestos_Compra(ID),

    CONSTRAINT FK_Ordenes_Compra_Usuario FOREIGN KEY(FK_Usuario)
    REFERENCES Usuarios(ID_Usuario)
);

CREATE TABLE Detalle_Ordenes_Compra(
    ID INT  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FK_Orden_Compra INT NOT NULL,
    FK_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario INT NOT NULL,

    CONSTRAINT FK_Detalle_Ordenes_Compra_Orden_Compra FOREIGN KEY(FK_Orden_Compra)
    REFERENCES Ordenes_Compra(ID),
    
    CONSTRAINT FK_Detalle_Ordenes_Compra_Producto FOREIGN KEY(FK_Producto)
    REFERENCES Productos(ID_Codigo)

);

